using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEXOSWEB.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using NEXOSWEB.Models.Responses;

namespace NEXOSWEB.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<AuthenticationController> _ILogger;
        public AuthenticationController(IHttpClientFactory clientFactory, ILogger<AuthenticationController> ILogger)
        {
            _clientFactory = clientFactory;
            _ILogger = ILogger;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginDTO login)
        {
            if (string.IsNullOrEmpty(login.email) || string.IsNullOrEmpty(login.password))
            {
                return RedirectToAction("Login");
            }

            try
            {
                var client = _clientFactory.CreateClient();
                var content = $"{{\"email\":\"{login.email}\",\"password\":\"{login.password}\"}}";
                var reponse = client
                    .PostAsync("https://localhost:44356/api/Account/authenticate", new StringContent(content, Encoding.UTF8, "application/json"))
                    .ConfigureAwait(false).GetAwaiter().GetResult();
                if (reponse.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<AuthticationResponse>(
                        reponse.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult());
                    var token = response.data.jwToken;
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, login.email) };
                    foreach (var item in response.data.roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item));
                    }                    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                    HttpContext.Session.SetString("ExpiryToken", token);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
                return RedirectToAction("error");
            }
        }
    }
}

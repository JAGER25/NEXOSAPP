using Newtonsoft.Json;
using NEXOSWEB.Interfaces;
using NEXOSWEB.Models;
using NEXOSWEB.Models.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEXOSWEB.Services
{
    public class AuthorServices : IAuthorServices
    {
        private AppSettings _appSettings;
        public async Task<List<AuthorViewModel>> GetAuthors(string token)
        {
            IRestResponse response = new RestResponse();
            try
            {
                var client = new RestClient(_appSettings.UrlApiAuthor);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"bearer {token}");
                request.AddHeader("Content-Type", "application/json");
                response = await client.ExecuteAsync(request);
                List<AuthorViewModel> aulas = JsonConvert.DeserializeObject<List<AuthorViewModel>>(response.Content);
                return aulas;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Error;
                response.ErrorMessage = ex.Message;
                response.ErrorException = ex;
                throw;
            }
        }
    }
}

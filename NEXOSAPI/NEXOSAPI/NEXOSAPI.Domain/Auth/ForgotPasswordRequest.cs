using System.ComponentModel.DataAnnotations;

namespace NEXOSAPI.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

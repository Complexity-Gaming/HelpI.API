using System.ComponentModel.DataAnnotations;

namespace HelpI.API.Security.Application.Transform.Resources
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
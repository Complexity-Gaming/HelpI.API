using System;
using System.ComponentModel.DataAnnotations;

namespace HelpI.API.Security.Application.Transform.Resources
{
    public class SavePlayerResource
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}

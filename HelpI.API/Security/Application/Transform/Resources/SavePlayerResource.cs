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
        [Url]
        public string ProfilePictureUrl { get; set; } =
            "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}

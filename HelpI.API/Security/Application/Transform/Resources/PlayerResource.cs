using HelpI.API.Security.Domain.Models;

namespace HelpI.API.Security.Application.Transform.Resources
{
    public class PlayerResource
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public PersonalProfile PersonalProfile { get; set; }
    }
}

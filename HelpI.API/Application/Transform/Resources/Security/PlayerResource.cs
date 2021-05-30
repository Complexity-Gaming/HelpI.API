using HelpI.API.Application.Transform.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Resources
{
    public class PlayerResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
    }
}

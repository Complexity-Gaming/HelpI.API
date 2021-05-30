using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Security
{
    public class PersonalDetail
    {
        public PersonalDetail(string firstName, string lastName, string email, string password, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Birthdate = birthdate;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime Birthdate { get; private set; }
    }
}

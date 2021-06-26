using System;
using System.Collections.Generic;
using HelpI.API.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Security.Domain.Models
{
 
    public class PersonalProfile : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthdate { get; private set; }
        
        public String ProfilePictureUrl { get; private set; }

        public PersonalProfile() { }
        
        public PersonalProfile(string firstName, string lastName, DateTime birthdate, String profilePictureUrl)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            ProfilePictureUrl = profilePictureUrl;
        }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return Birthdate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Application
{
    public class ApplicationDetails
    {
        public ApplicationDetails(string description, Uri videoApplication, bool passed)
        {
            Description = description;
            VideoApplication = videoApplication;
            Passed = passed;
        }

        public string Description { get; private set; }
        public Uri VideoApplication { get; private set; }
        public bool Passed { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Application
{
    public class ApplicationDetail : ValueObject
    {
        public ApplicationDetail()
        {

        }

        public ApplicationDetail(string description, Uri videoApplication, bool passed)
        {
            Description = description;
            VideoApplication = videoApplication;
            Passed = passed;
        }

        public string Description { get; private set; }
        public Uri VideoApplication { get; private set; }
        public bool Passed { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Description;
            yield return VideoApplication;
            yield return Passed; 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace HelpI.API.Domain.Models.Application
{
    public class ApplicationDetail : ValueObject
    {
        public ApplicationDetail(string description, Uri videoApplication, EApplicationStatus status, string reviewComment)
        {
            Description = description;
            VideoApplication = videoApplication;
            Status = status;
            ReviewComment = reviewComment;
        }

        public string Description { get; private set; }
        public Uri VideoApplication { get; private set; }
        public string ReviewComment { get; private set; }
        public EApplicationStatus Status { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Description;
            yield return VideoApplication;
            yield return Status; 
        }
    }
}

using System;
using System.Collections.Generic;
using HelpI.API.Security.Domain.Models;
using HelpI.API.SeedWork;

namespace HelpI.API.Application.Domain.Models
{
    public class ApplicationForm : ValueObject
    {
        public ApplicationForm()
        {
            
        }
        public ApplicationForm(string description, Uri videoApplication, EApplicationStatus status, string reviewComment)
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
            yield return ReviewComment;
        }
    }
}

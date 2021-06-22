using System.Collections.Generic;
using HelpI.API.SeedWork;

namespace HelpI.API.Session.Domain.Models
{
    public class SessionReview : ValueObject
    {
        public SessionReview()
        {
        }

        public SessionReview(string comment, short review)
        {
            this.Comment = comment;
            this.Review = review;
        }

        public string Comment { get; private set; }
        public short Review { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Comment;
            yield return Review;
        }
    }
}

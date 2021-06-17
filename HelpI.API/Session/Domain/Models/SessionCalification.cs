using System.Collections.Generic;
using HelpI.API.SeedWork;

namespace HelpI.API.Session.Domain.Models
{
    public class SessionCalification : ValueObject
    {
        public SessionCalification()
        {
        }

        public SessionCalification(string comment, short calification)
        {
            this.Comment = comment;
            this.Calification = calification;
        }

        public string Comment { get; private set; }
        public short Calification { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Comment;
            yield return Calification;
        }
    }
}

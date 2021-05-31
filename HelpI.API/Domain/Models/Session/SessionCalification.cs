using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Session
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

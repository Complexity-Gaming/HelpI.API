using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Session
{
    public class SessionDate : ValueObject
    {
        public SessionDate()
        {
        }

        public SessionDate(DateTime date, short duration)
        {
            this.Date = date;
            this.Duration = duration;
        }

        public DateTime Date { get; private set; }
        public short Duration { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Date;
            yield return Duration;
        }
    }
}

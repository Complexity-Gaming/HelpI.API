using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Session
{
    public class SessionDetails
    {
        public SessionDetails(DateTime date, short duration)
        {
            this.date = date;
            this.duration = duration;
        }

        public DateTime date { get; private set; }
        public short duration { get; private set; }
    }
}

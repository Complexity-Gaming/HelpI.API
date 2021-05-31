using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Session
{
    public class SessionCalification
    {
        public SessionCalification(string comment, short calification)
        {
            this.comment = comment;
            this.calification = calification;
        }

        public string comment { get; private set; }
        public short calification { get; private set; }
    }
}

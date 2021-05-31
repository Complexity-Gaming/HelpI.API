using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Session
{
    public class IndSessionId
    {
        public IndSessionId(string individualSessionId)
        {
            IndividualSessionId = individualSessionId;
        }

        public string IndividualSessionId { get; private set; }
    }
}

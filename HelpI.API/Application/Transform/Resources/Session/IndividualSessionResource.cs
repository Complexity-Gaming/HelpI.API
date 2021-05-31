using HelpI.API.Domain.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Resources.Session
{
    public class IndividualSessionResource
    {
        public int Id { get; set; }
        public string IndividualSessionId { get; set; }
        public SessionCalification Calification { get; set; }
        public SessionDetails Details { get; set; }
    }
}

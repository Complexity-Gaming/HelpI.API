using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Application
{
    public class CoachApplication
    {
        public string Id { get; set; }
        public AplicationId CoachAplicationId { get; }
        public ApplicationDetail ApplicationDetails { get; }
    }
}

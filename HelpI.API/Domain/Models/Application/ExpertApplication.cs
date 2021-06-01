using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Security;

namespace HelpI.API.Domain.Models.Application
{
    public class ExpertApplication
    {
        public int Id { get; set; }
        public ApplicationId ExpertApplicationId { get; set; }
        public ApplicationDetail ApplicationDetails { get; set; }
        public int PlayerId { get; set; }
        public Player Applicant { get; set; }
    }
}

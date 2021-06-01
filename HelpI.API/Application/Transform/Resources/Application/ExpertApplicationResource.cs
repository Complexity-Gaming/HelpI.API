using HelpI.API.Domain.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Resources.Application
{
    public class ExpertApplicationResource
    {
        public int Id { get; set; }
        public string ExpertApplicationId { get; set; }
        public string Description { get; set; }
        public Uri VideoApplication { get; set; }
        public string Status { get; set; }
        public PlayerResource Applicant { get; set; }
    }
}

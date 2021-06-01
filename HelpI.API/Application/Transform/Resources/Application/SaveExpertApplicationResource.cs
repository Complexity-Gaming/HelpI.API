using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Resources.Application
{
    public class SaveExpertApplicationResource
    {
        public string ExpertApplicationId { get; set; }
        public string Description { get; set; }
        public Uri VideoApplication { get; set; }
    }
}

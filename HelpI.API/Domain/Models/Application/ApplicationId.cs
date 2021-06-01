using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Application
{
    public class ApplicationId
    {
        public ApplicationId(string expertApplicationId)
        {
            ExpertApplicationId = expertApplicationId;
        }

        public string ExpertApplicationId { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Application
{
    public class AplicationId
    {
        public AplicationId(string coachApplicationId)
        {
            CoachApplicationId = coachApplicationId;
        }

        public string CoachApplicationId { get; private set; }
    }
}

using HelpI.API.Domain.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Resources.Application
{
    public class CoachApplicationResource
    {
        public int Id { get; set; }
        public ApplicationDetails ApplicationDetails { get; set; }
    }
}

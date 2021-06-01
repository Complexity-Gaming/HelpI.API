using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Application;

namespace HelpI.API.Domain.Models.Security
{
    public class Player : User
    {
        public IList<PlayerTrainingMaterial> PlayerTrainingMaterials { get; set; } = new List<PlayerTrainingMaterial>();
        public IList<ExpertApplication> ExpertApplications { get; set; } = new List<ExpertApplication>();
    }
}

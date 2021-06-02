using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Models.Session;

namespace HelpI.API.Domain.Models.Security
{
    public class Player : User
    {
        public IList<ScheduledSession> Schedule { get; set; }
        
        public IList<IndividualSession> AssistedSessions { get; set; }
        public IList<PlayerTrainingMaterial> PlayerTrainingMaterials { get; set; } = new List<PlayerTrainingMaterial>();
        public IList<ExpertApplication> ExpertApplications { get; set; } = new List<ExpertApplication>();
    }
}

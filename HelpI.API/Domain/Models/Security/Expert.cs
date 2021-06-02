using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Session;

namespace HelpI.API.Domain.Models.Security
{
    public class Expert : User
    {
        public Expert()
        {
            
        }
        public Expert(Player player)
        {
            this.Email = player.Email;
            this.FirstName = player.FirstName;
            this.LastName = player.LastName;
            this.Birthdate = player.Birthdate;
            this.Password = player.Password;
            this.TrainingMaterials = new List<TrainingMaterial>();
        }
        public IList<ScheduledSession> Schedule { get; set; }
        public IList<TrainingMaterial> TrainingMaterials { get; set; } = new List<TrainingMaterial>();
        public IList<IndividualSession> GivenSessions { get; set; }
    }
}


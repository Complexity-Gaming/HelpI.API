using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Security
{
    public abstract class User
    {
        public int Id { get; set; }
        public PersonalDetail PersonalDetails { get; set; }
        public List<PlayerTrainingMaterial> PlayerTrainingMaterials { get; set; } = new List<PlayerTrainingMaterial>();
    }
}

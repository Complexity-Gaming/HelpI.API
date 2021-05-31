using HelpI.API.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Training
{
    public class TrainingMaterial
    {
        public int Id { get; set; }
        public TrainingId TrainingMaterialId { get; }
        public TrainingDetail TrainingDetails { get; }
        public int ExpertId { get; set; }
        public Expert CreatedBy { get; set; }
        public List<PlayerTrainingMaterial> PlayerTrainingMaterials { get; set; }
    }
}

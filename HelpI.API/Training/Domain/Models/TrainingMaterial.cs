using System.Collections.Generic;
using HelpI.API.Security.Domain.Models;

namespace HelpI.API.Training.Domain.Models
{
    public class TrainingMaterial
    {
        public int Id { get; set; }
        public TrainingId TrainingMaterialId { get; set; }
        public TrainingDetail TrainingDetails { get; set; }
        public int ExpertId { get; set; }
        public Expert CreatedBy { get; set; }
        public List<PlayerTrainingMaterial> PlayerTrainingMaterials { get; set; }
    }
}

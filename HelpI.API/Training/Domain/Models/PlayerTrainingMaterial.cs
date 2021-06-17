using HelpI.API.Security.Domain.Models;

namespace HelpI.API.Training.Domain.Models
{
    public class PlayerTrainingMaterial
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TrainingMaterialId { get; set; }
        public TrainingMaterial TrainingMaterial { get; set; }
    }
}

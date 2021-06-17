namespace HelpI.API.Training.Domain.Models
{
    public class TrainingId
    {
        public TrainingId(string trainingMaterialId)
        {
            TrainingMaterialId = trainingMaterialId;
        }

        public string TrainingMaterialId { get; private set; }
    }
}

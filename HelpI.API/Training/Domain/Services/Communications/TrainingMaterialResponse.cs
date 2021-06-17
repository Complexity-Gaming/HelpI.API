using HelpI.API.SeedWork.Communications;
using HelpI.API.Training.Domain.Models;

namespace HelpI.API.Training.Domain.Services.Communications
{
    public class TrainingMaterialResponse : BaseResponse<TrainingMaterial>
    {
        public TrainingMaterialResponse(TrainingMaterial resource) : base(resource)
        {
        }

        public TrainingMaterialResponse(string message) : base(message)
        {
        }
    }
}

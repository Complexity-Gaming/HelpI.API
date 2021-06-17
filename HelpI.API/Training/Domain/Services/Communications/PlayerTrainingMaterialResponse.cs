using HelpI.API.SeedWork.Communications;
using HelpI.API.Training.Domain.Models;

namespace HelpI.API.Training.Domain.Services.Communications
{
    public class PlayerTrainingMaterialResponse : BaseResponse<PlayerTrainingMaterial>
    {
        public PlayerTrainingMaterialResponse(PlayerTrainingMaterial resource) : base(resource)
        {
        }

        public PlayerTrainingMaterialResponse(string message) : base(message)
        {
        }
    }
}

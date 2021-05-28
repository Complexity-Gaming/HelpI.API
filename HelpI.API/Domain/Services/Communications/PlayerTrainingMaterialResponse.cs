using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Communications
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

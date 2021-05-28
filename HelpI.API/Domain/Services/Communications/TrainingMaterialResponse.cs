using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Communications
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

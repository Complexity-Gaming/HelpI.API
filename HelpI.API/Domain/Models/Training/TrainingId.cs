using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Training
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Resources.Training
{
    public class SaveTrainingMaterialResource
    {
        public string TrainingMaterialId { get; set; }
        public Uri VideoUri { get; set; }
        public string Currency { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

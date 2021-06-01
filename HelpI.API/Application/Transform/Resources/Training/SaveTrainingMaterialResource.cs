using System;
using System.ComponentModel.DataAnnotations;

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

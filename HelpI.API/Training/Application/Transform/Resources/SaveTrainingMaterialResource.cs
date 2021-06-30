using System;
using System.ComponentModel.DataAnnotations;

namespace HelpI.API.Training.Application.Transform.Resources
{
    public class SaveTrainingMaterialResource
    {
        public string TrainingMaterialId { get; set; }
        public Uri VideoUri { get; set; }
        public int GameId { get; set; }
        public string Description { get; set; } 
        public string Currency { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

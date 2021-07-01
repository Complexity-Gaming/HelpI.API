using System;
using HelpI.API.Security.Application.Transform.Resources;
using IGDB.Models;

namespace HelpI.API.Training.Application.Transform.Resources
{
    public class TrainingMaterialResource
    {
        public int Id { get; set; }
        public string TrainingMaterialId { get; set; }
        public Uri VideoUri { get; set; }

        public int GameId { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public ExpertResource CreatedBy { get; set; }
    }
}

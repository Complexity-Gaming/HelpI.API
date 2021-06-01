using System;

namespace HelpI.API.Application.Transform.Resources.Training
{
    public class TrainingMaterialResource
    {
        public int Id { get; set; }
        public string TrainingMaterialId { get; set; }
        public Uri VideoUri { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public ExpertResource CreatedBy { get; set; }
    }
}

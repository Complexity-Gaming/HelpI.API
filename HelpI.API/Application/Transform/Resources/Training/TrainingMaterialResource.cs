using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Resources
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

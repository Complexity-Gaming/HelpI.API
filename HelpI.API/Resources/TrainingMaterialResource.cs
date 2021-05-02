using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Resources
{
    public class TrainingMaterialResource
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public ExpertResource CreatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models
{
    public class TrainingMaterial
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int ExpertId { get; set; }
        public Expert CreatedBy { get; set; }
    }
}

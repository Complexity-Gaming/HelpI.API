using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models
{
    public class Expert : Person
    {
        public IList<TrainingMaterial> TrainingMaterials { get; set; } = new List<TrainingMaterial>();
    }
}

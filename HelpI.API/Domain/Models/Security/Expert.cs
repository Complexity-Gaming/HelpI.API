﻿using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Security
{
    public class Expert : User
    {
        public IList<TrainingMaterial> TrainingMaterials { get; set; } = new List<TrainingMaterial>();
    }
}

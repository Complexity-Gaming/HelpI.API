﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models
{
    public class PlayerTrainingMaterial
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TrainingMaterialId { get; set; }
        public TrainingMaterial TrainingMaterial { get; set; }
       
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Resources
{
    public class SaveTrainingMaterialResource
    {
        [Required]
        public decimal Price { get; set; }
    }
}

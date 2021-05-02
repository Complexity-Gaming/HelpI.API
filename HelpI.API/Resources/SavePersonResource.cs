using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Resources
{
    public class SavePersonResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}

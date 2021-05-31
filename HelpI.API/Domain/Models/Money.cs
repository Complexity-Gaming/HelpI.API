using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models
{
    public class Money
    {
        public string Currency { get; set; }
        public decimal Ammount { get; set; }
    }
}

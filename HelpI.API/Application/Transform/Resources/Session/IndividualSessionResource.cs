using HelpI.API.Domain.Models.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Resources.Session
{
    public class IndividualSessionResource
    {
        public int Id { get; set; }
        public string IndividualSessionId { get; set; }
        public SessionCalification SessionCalification { get; set; }
        public DateTime Date { get; set; }
        public short Duration { get; set; }
        public string Currency { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ExpertResource Expert { get; set; }
        public PlayerResource Player { get; set; }
    }
}

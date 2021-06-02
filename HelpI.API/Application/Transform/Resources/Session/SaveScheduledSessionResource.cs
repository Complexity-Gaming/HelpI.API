using System;
using System.ComponentModel.DataAnnotations;

namespace HelpI.API.Application.Transform.Resources.Session
{
    public class SaveScheduledSessionResource
    {
        public string ScheduledSessionId { get; set; }
        public string Currency { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public short Duration { get; set; }
        public int PlayerId { get; set; }
        public int ExpertId { get; set; }

    }
}
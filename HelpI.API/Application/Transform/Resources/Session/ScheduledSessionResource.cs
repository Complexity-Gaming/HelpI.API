using System;
using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Session;

namespace HelpI.API.Application.Transform.Resources.Session
{
    public class ScheduledSessionResource
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public string ScheduledSessionId { get; set; }
        public DateTime Date { get; set; }
        public short Duration { get; set; }
        public ExpertResource Expert { get; set; }
        public PlayerResource Player { get; set; }
    }
}
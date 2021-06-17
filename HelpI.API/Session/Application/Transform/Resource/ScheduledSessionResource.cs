using System;
using HelpI.API.Security.Application.Transform.Resources;

namespace HelpI.API.Session.Application.Transform.Resource
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
using System;
using System.ComponentModel.DataAnnotations;
using HelpI.API.Security.Application.Transform.Resources;
using HelpI.API.Session.Domain.Models;

namespace HelpI.API.Session.Application.Transform.Resource
{
    public class CoachingSessionResource
    {
        public int Id { get; set; }
        public string IndividualSessionId { get; set; }
        public SessionReview SessionReview { get; set; }
        public DateTime Date { get; set; }
        public short Duration { get; set; }
        public string Currency { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ExpertResource Expert { get; set; }
        public PlayerResource Player { get; set; }
    }
}

using System;
using System.Collections.Generic;
using AutoMapper.Mappers;
using HelpI.API.SeedWork;

namespace HelpI.API.Security.Domain.Models
{
    public class ExpertProfile : ValueObject
    {
        public ExpertProfile()
        {
            
        }
        public ExpertProfile(string elo, string gameUserName, string experienceStory, string whyMe, DateTime startedPlaying)
        {
            Elo = elo;
            GameUserName = gameUserName;
            ExperienceStory = experienceStory;
            WhyMe = whyMe;
            StartedPlaying = startedPlaying;
        }

        public String Elo { get; private set; }
        public String GameUserName { get; private set; }
        public String ExperienceStory { get; private set; }
        public String WhyMe { get; private set; }
        public DateTime StartedPlaying { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Elo;
            yield return GameUserName;
            yield return ExperienceStory;
            yield return WhyMe;
            yield return StartedPlaying;
        }
    }
}
﻿using System;
using AutoMapper;
using HelpI.API.Domain.Models;
using HelpI.API.Application.Transform.Resources;
using HelpI.API.Application.Transform.Resources.Application;
using HelpI.API.Application.Transform.Resources.Session;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Training;
using HelpI.API.Domain.Models.Application;
using HelpI.API.Application.Transform.Resources.Training;
using HelpI.API.Domain.Models.Session;
using ApplicationId = HelpI.API.Domain.Models.Application.ApplicationId;


namespace HelpI.API.Application.Transform.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePlayerResource, Player>();
            CreateMap<SaveExpertResource, Expert>();

            CreateMap<SaveExpertApplicationResource, ExpertApplication>()
                .ForMember(src => src.ExpertApplicationId,
                    opt => opt.MapFrom(src => 
                        new ApplicationId(src.ExpertApplicationId)))
                .ForMember(src => src.ApplicationDetails,
                    opt => opt.MapFrom(src => 
                        new ApplicationDetail(src.Description, src.VideoApplication, EApplicationStatus.Pending, null)));
            
            CreateMap<SaveScheduledSessionResource, ScheduledSession>()
                .ForMember(src => src.Price,
                    opt => opt.MapFrom(src => new Money(src.Currency, src.Price)))
                .ForMember(src => src.ScheduledSessionId,
                    opt => opt.MapFrom(src => new ScheSessionId(src.ScheduledSessionId)))
                .ForMember(src => src.SessionDate,
                    opt => opt.MapFrom(src => new SessionDate(src.Date, src.Duration)));

            CreateMap<SaveTrainingMaterialResource, TrainingMaterial>()
                .ForMember(src => src.TrainingMaterialId,
                opt => opt.MapFrom(src => new TrainingId(src.TrainingMaterialId)))
                .ForMember(src => src.TrainingDetails,
                opt => opt.MapFrom(src => new TrainingDetail(src.VideoUri, DateTime.Now, src.Currency, src.Price)));


        }
    }
}

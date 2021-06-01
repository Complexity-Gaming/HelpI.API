using AutoMapper;
using HelpI.API.Application.Transform.Resources;
using HelpI.API.Application.Transform.Resources.Session;
using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Application.Transform.Resources.Application;
using HelpI.API.Application.Transform.Resources.Training;
using HelpI.API.Application.Extensions;
using HelpI.API.Application.Transform.Resources.Training;

namespace HelpI.API.Application.Transform.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Player, PlayerResource>()
                .ForMember(src => src.Birthdate,
                opt => opt.MapFrom(src => src.Birthdate.Date));

            CreateMap<Expert, ExpertResource>()
                .ForMember(src => src.Birthdate,
                opt => opt.MapFrom(src => src.Birthdate.Date));

            CreateMap<ExpertApplication, ExpertApplicationResource>()
                .ForMember(src => src.ExpertApplicationId,
                    opt => opt.MapFrom(src => src.ExpertApplicationId.ExpertApplicationId))
                .ForMember(src => src.Description,
                    opt => opt.MapFrom(src => src.ApplicationDetails.Description))
                .ForMember(src => src.VideoApplication,
                    opt => opt.MapFrom(src => src.ApplicationDetails.VideoApplication))
                .ForMember(src => src.Status,
                    opt => opt.MapFrom(src => src.ApplicationDetails.Status.ToDescriptionString()));
            
            CreateMap<IndividualSession, IndividualSessionResource>();
            CreateMap<ScheduledSession, ScheduledSessionResource>();

            CreateMap<TrainingMaterial, TrainingMaterialResource>()
                 .ForMember(src => src.TrainingMaterialId,
                opt => opt.MapFrom(src => src.TrainingMaterialId.TrainingMaterialId))
                .ForMember(src => src.VideoUri,
                opt => opt.MapFrom(src => src.TrainingDetails.VideoUri))
                 .ForMember(src => src.PublishedDate,
                opt => opt.MapFrom(src => src.TrainingDetails.PublishedDate))
                 .ForMember(src => src.Currency,
                opt => opt.MapFrom(src => src.TrainingDetails.Currency))
                 .ForMember(src => src.Price,
                opt => opt.MapFrom(src => src.TrainingDetails.Price));

        }
    }
}

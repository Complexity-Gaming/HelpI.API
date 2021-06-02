using AutoMapper;
using HelpI.API.Application.Transform.Resources;
using HelpI.API.Application.Transform.Resources.Session;
using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Models.Training;
using HelpI.API.Application.Transform.Resources.Application;
using HelpI.API.Application.Transform.Resources.Training;
using HelpI.API.Application.Extensions;

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

            CreateMap<IndividualSession, IndividualSessionResource>()
                .ForMember(src => src.IndividualSessionId,
                    opt => opt.MapFrom(src => src.IndividualSessionId.IndividualSessionId))
                .ForMember(src => src.Currency,
                    opt => opt.MapFrom(src => src.Price.Currency))
                .ForMember(src => src.Price,
                    opt => opt.MapFrom(src => src.Price.Amount))
                .ForMember(src => src.Date,
                    opt => opt.MapFrom(src => src.SessionDate.Date))
                .ForMember(src => src.Duration,
                    opt => opt.MapFrom(src => src.SessionDate.Duration));
            ;
            
            CreateMap<ScheduledSession, ScheduledSessionResource>()
                .ForMember(src => src.Currency,
                    opt => opt.MapFrom(src => src.Price.Currency))
                .ForMember(src => src.Price,
                    opt => opt.MapFrom(src => src.Price.Amount))
                .ForMember(src => src.ScheduledSessionId,
                    opt => opt.MapFrom(src => src.ScheduledSessionId.ScheduledSessionId))
                .ForMember(src => src.Date,
                    opt => opt.MapFrom(src => src.SessionDate.Date))
                .ForMember(src => src.Duration,
                    opt => opt.MapFrom(src => src.SessionDate.Duration));
            ;

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

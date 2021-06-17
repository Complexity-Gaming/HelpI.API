using AutoMapper;
using HelpI.API.Application.Application.Transform.Resources;
using HelpI.API.Application.Domain.Models;
using HelpI.API.Security.Application.Transform.Resources;
using HelpI.API.Security.Domain.Models;
using HelpI.API.SeedWork.Extensions;
using HelpI.API.Session.Application.Transform.Resource;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Training.Application.Transform.Resources;
using HelpI.API.Training.Domain.Models;

namespace HelpI.API.SeedWork.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Player, PlayerResource>();

            CreateMap<Expert, ExpertResource>();

            CreateMap<ExpertApplication, ExpertApplicationResource>()
                .ForMember(src => src.Description,
                    opt => opt.MapFrom(src => src.ApplicationForm.Description))
                .ForMember(src => src.VideoApplication,
                    opt => opt.MapFrom(src => src.ApplicationForm.VideoApplication))
                .ForMember(src => src.Status,
                    opt => opt.MapFrom(src => src.ApplicationForm.Status.ToDescriptionString()));

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

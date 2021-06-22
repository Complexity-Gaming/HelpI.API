using System;
using AutoMapper;
using HelpI.API.Application.Application.Transform.Resources;
using HelpI.API.Application.Domain.Models;
using HelpI.API.Security.Application.Transform.Resources;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Training.Application.Transform.Resources;
using HelpI.API.Training.Domain.Models;


namespace HelpI.API.SeedWork.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePlayerResource, Player>().ForMember(src => src.PersonalProfile,
                opt => opt.MapFrom(src => new PersonalProfile(src.FirstName, src.LastName, src.Birthdate)));
            CreateMap<SaveExpertResource, Expert>();

            CreateMap<SaveExpertApplicationResource, ExpertApplication>()
                .ForMember(src => src.GameId,
                    opt => opt.MapFrom(src => 
                        src.GameId))
                .ForMember(src => src.ApplicationForm,
                    opt => opt.MapFrom(src => 
                        new ApplicationForm(src.Description, src.VideoApplication, EApplicationStatus.Pending, null)));
            

            CreateMap<SaveTrainingMaterialResource, TrainingMaterial>()
                .ForMember(src => src.TrainingMaterialId,
                opt => opt.MapFrom(src => new TrainingId(src.TrainingMaterialId)))
                .ForMember(src => src.TrainingDetails,
                opt => opt.MapFrom(src => new TrainingDetail(src.VideoUri, DateTime.Now, src.Currency, src.Price)));


        }
    }
}

using AutoMapper;
using HelpI.API.Domain.Models;
using HelpI.API.Application.Transform.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Training;
using HelpI.API.Domain.Models.Application;
using HelpI.API.Application.Transform.Resources.Application;
using HelpI.API.Application.Transform.Resources.Session;
using HelpI.API.Domain.Models.Session;


namespace HelpI.API.Application.Transform.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePlayerResource, Player>();
            CreateMap<SaveExpertResource, Expert>();
 
            CreateMap<SaveCoachAplicationResource, CoachApplication>();

  
            CreateMap<SaveIndividualSessionResource, IndividualSession>();

            CreateMap<SaveTrainingMaterialResource, TrainingMaterial>()
                .ForMember(src => src.TrainingMaterialId,
                opt => opt.MapFrom(src => new TrainingId(src.TrainingMaterialId)))
                .ForMember(src => src.TrainingDetails,
                opt => opt.MapFrom(src => new TrainingDetail(src.VideoUri, DateTime.Now, src.Currency, src.Price)));


        }
    }
}

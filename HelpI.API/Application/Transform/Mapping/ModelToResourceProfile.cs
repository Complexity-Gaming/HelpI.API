using AutoMapper;
using HelpI.API.Application.Transform.Resources;
using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Transform.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Player, PlayerResource>()
                .ForMember(src => src.Birthdate,
                opt => opt.MapFrom(src => src.Birthdate.Date.ToString()));

            CreateMap<Expert, ExpertResource>()
                .ForMember(src => src.Birthdate,
                opt => opt.MapFrom(src => src.Birthdate.Date.ToString()));
            CreateMap<TrainingMaterial, TrainingMaterialResource>();
        }
    }
}

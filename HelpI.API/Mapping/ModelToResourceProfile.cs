using AutoMapper;
using HelpI.API.Domain.Models;
using HelpI.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Person, PersonResource>();
            CreateMap<Player, PlayerResource>();
            CreateMap<Expert, ExpertResource>();
        }
    }
}

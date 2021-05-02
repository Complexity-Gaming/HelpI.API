using AutoMapper;
using HelpI.API.Domain.Models;
using HelpI.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePersonResource, Person>();
            CreateMap<SavePlayerResource, Player>();
            CreateMap<SaveExpertResource, Expert>();
        }
    }
}

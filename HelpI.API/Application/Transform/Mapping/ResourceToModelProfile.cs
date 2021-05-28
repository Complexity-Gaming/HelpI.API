using AutoMapper;
using HelpI.API.Domain.Models;
using HelpI.API.Application.Transform.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Training;

namespace HelpI.API.Application.Transform.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePersonResource, Person>();
            CreateMap<SavePlayerResource, Player>();
            CreateMap<SaveExpertResource, Expert>();
            CreateMap<SaveTrainingMaterialResource, TrainingMaterial>();
        }
    }
}

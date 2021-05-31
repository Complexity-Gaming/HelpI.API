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

namespace HelpI.API.Application.Transform.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePlayerResource, Player>();
            CreateMap<SaveExpertResource, Expert>();
            CreateMap<SaveTrainingMaterialResource, TrainingMaterial>();
            CreateMap<SaveCoachAplicationResource, CoachApplication>();
        }
    }
}

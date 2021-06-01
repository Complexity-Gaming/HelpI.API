using HelpI.API.Domain.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Communications
{
    public class ExpertApplicationResponse : BaseResponse<ExpertApplication>
    {
        public ExpertApplicationResponse(ExpertApplication resource) : base(resource)
        {
        }

        public ExpertApplicationResponse(string message) : base(message)
        {
        }
    }
}

using HelpI.API.Domain.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Communications
{
    public class CoachApplicationRespose : BaseResponse<CoachApplication>
    {
        public CoachApplicationRespose(CoachApplication resource) : base(resource)
        {
        }

        public CoachApplicationRespose(string message) : base(message)
        {
        }
    }
}

using HelpI.API.Domain.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Communications
{
    public class IndividualSessionResponse : BaseResponse<IndividualSession>
    {
        public IndividualSessionResponse(IndividualSession resource) : base(resource)
        {
        }

        public IndividualSessionResponse(string message) : base(message)
        {
        }
    }
}

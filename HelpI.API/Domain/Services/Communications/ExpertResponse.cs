using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Communications
{
    public class ExpertResponse : BaseResponse<Expert>
    {
        public ExpertResponse(Expert resource) : base(resource)
        {
        }

        public ExpertResponse(string message) : base(message)
        {
        }
    }
}

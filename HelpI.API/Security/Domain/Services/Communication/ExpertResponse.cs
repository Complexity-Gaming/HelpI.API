using HelpI.API.Security.Domain.Models;
using HelpI.API.SeedWork.Communications;

namespace HelpI.API.Security.Domain.Services.Communication
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

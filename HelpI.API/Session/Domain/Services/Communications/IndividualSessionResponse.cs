using HelpI.API.SeedWork.Communications;
using HelpI.API.Session.Domain.Models;

namespace HelpI.API.Session.Domain.Services.Communications
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

using HelpI.API.SeedWork.Communications;
using HelpI.API.Session.Domain.Models;

namespace HelpI.API.Session.Domain.Services.Communications
{
    public class CoachingSessionResponse : BaseResponse<CoachingSession>
    {
        public CoachingSessionResponse(CoachingSession resource) : base(resource)
        {
        }

        public CoachingSessionResponse(string message) : base(message)
        {
        }
    }
}

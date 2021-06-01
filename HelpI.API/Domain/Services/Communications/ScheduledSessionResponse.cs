using HelpI.API.Domain.Models.Session;

namespace HelpI.API.Domain.Services.Communications
{
    public class ScheduledSessionResponse: BaseResponse<ScheduledSession>
    {
        public ScheduledSessionResponse(ScheduledSession resource) : base(resource)
        {
        }

        public ScheduledSessionResponse(string message) : base(message)
        {
        }
    }
}
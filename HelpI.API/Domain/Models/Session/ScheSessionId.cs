namespace HelpI.API.Domain.Models.Session
{
    public class ScheSessionId
    {
        public ScheSessionId(string scheduledSessionId)
        {
            ScheduledSessionId = scheduledSessionId;
        }
        public string ScheduledSessionId { get; private set; }
    }
}
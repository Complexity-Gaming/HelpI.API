using HelpI.API.Domain.Models.Security;

namespace HelpI.API.Domain.Models.Session
{
    public class ScheduledSession
    {
        public int Id { get; set; }
        public Money Price { get; set; }
        public ScheSessionId ScheduledSessionId { get; set; }
        public SessionDate SessionDate { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }

    }   
}       
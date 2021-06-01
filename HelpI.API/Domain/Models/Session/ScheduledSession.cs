namespace HelpI.API.Domain.Models.Session
{
    public class ScheduledSession
    {
        public int Id { get; set; }
        public Money Price { get; set; }
        public ScheSessionId ScheduledSessionId { get; }
        public SessionDate SessionDate { get; set; }
        
    }   
}       
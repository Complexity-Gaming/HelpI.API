namespace HelpI.API.Session.Domain.Models
{
    public class SessionId
    {
        public SessionId(string individualSessionId)
        {
            IndividualSessionId = individualSessionId;
        }
        public string IndividualSessionId { get; private set; }
    }
}

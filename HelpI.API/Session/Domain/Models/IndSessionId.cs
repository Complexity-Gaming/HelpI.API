namespace HelpI.API.Session.Domain.Models
{
    public class IndSessionId
    {
        public IndSessionId(string individualSessionId)
        {
            IndividualSessionId = individualSessionId;
        }
        public string IndividualSessionId { get; private set; }
    }
}

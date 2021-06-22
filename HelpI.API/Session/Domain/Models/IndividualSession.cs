using HelpI.API.Security.Domain.Models;
using HelpI.API.SeedWork;

namespace HelpI.API.Session.Domain.Models
{
    public class IndividualSession
    {
        //Todo: Rename Session Review(typo)
        public IndividualSession()
        {
            
        }
        public IndividualSession(string sessionId, SessionDate sessionDate, int playerId, int expertId, Money price)
        {
            SessionId = new SessionId(sessionId);
            SessionDate = sessionDate;
            PlayerId = playerId;
            ExpertId = expertId;
            Price = price;
        }

        public int Id { get; set; }
        public SessionId SessionId { get; set; }
        public SessionReview SessionReview { get; set; }
        public SessionDate SessionDate { get; set; }
        public Money Price { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }

    }
}

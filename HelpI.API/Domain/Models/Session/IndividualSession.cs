using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Security;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Org.BouncyCastle.Crypto.Engines;

namespace HelpI.API.Domain.Models.Session
{
    public class IndividualSession
    {
        //Todo: Rename Session Calification(typo)
        public IndividualSession()
        {
            
        }
        public IndividualSession(string sessionId, SessionDate sessionDate, int playerId, int expertId, Money price)
        {
            IndividualSessionId = new IndSessionId(sessionId);
            SessionDate = sessionDate;
            PlayerId = playerId;
            ExpertId = expertId;
            Price = price;
        }

        public int Id { get; set; }
        public IndSessionId IndividualSessionId { get; set; }
        public SessionCalification SessionCalification { get; set; }
        public SessionDate SessionDate { get; set; }
        public Money Price { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }

    }
}

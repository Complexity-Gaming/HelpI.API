using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Session.Domain.Services.Communications;

namespace HelpI.API.Session.Domain.Services
{
    public interface ICoachingSessionService
    {
        Task<IEnumerable<CoachingSession>> ListAsync();
        Task<CoachingSessionResponse> GetByIdAsync(int id);
        Task<IEnumerable<CoachingSession>> ListByExpertIdAsync(int expertId);
        Task<IEnumerable<CoachingSession>> ListByPlayerIdAsync(int playerId);
        Task<IEnumerable<CoachingSession>> ListByPlayerIdAndExpertId(int playerId, int expertId);
        Task<CoachingSessionResponse> StartSession(int scheduledSessionId);
        Task<CoachingSessionResponse> EndSession(int sessionId, SessionReview review);
        Task<CoachingSessionResponse> DeleteAsync(int id);
    }
}

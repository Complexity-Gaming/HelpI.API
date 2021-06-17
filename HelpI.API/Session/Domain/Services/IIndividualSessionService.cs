using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Session.Domain.Services.Communications;

namespace HelpI.API.Session.Domain.Services
{
    public interface IIndividualSessionService
    {
        Task<IEnumerable<IndividualSession>> ListAsync();
        Task<IndividualSessionResponse> GetByIdAsync(int id);
        Task<IEnumerable<IndividualSession>> ListByExpertIdAsync(int expertId);
        Task<IEnumerable<IndividualSession>> ListByPlayerIdAsync(int playerId);
        Task<IEnumerable<IndividualSession>> ListByPlayerIdAndExpertId(int playerId, int expertId);
        Task<IndividualSessionResponse> StartSession(int scheduledSessionId);
        Task<IndividualSessionResponse> EndSession(int sessionId, SessionCalification calification);
        Task<IndividualSessionResponse> DeleteAsync(int id);
    }
}

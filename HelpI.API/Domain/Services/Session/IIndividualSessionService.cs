using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Session
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

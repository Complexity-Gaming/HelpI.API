using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Services.Communications;

namespace HelpI.API.Domain.Services.Session
{
    public interface IScheduledSessionService
    {
        Task<IEnumerable<ScheduledSession>> ListAsync();
        Task<ScheduledSessionResponse> GetByIdAsync(int id);
        Task<IEnumerable<ScheduledSession>> ListByExpertIdAsync(int expertId);
        Task<IEnumerable<ScheduledSession>> ListByPlayerIdAsync(int playerId);
        Task<IEnumerable<ScheduledSession>> ListByPlayerIdAndExpertId(int playerId, int expertId);
        Task<ScheduledSessionResponse> ScheduleSession(ScheduledSession scheduledSession);
        Task<ScheduledSessionResponse> DeleteAsync(int id);
    }
}
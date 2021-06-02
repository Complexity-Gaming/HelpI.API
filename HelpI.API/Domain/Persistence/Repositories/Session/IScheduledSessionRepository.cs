using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Session;

namespace HelpI.API.Domain.Persistence.Repositories.Session
{
    public interface IScheduledSessionRepository
    {
        Task<IEnumerable<ScheduledSession>> ListAsync();
        Task<ScheduledSession> FindById(int id);
        Task AddAsync(ScheduledSession scheduledSession);
        Task<IEnumerable<ScheduledSession>> ListByPlayerIdAsync(int playerId);
        Task<IEnumerable<ScheduledSession>> ListByExpertIdAsync(int expertId);
        Task<IEnumerable<ScheduledSession>> FindByPlayerIdAndExpertId(int playerId, int expertId);
        void Remove(ScheduledSession scheduledSession);
    }
}
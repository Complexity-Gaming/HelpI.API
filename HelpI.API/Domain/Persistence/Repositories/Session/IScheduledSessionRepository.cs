using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Session;

namespace HelpI.API.Domain.Persistence.Repositories.Session
{
    public interface IScheduledSessionRepository
    {
        Task<IEnumerable<ScheduledSession>> ListAsync();
        Task<ScheduledSession> FindById(int id);
        void Remove(ScheduledSession scheduledSession);
    }
}
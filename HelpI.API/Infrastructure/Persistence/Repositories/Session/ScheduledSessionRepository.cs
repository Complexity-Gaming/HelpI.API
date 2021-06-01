using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Persistence.Contexts;
using HelpI.API.Domain.Persistence.Repositories.Session;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Infrastructure.Persistence.Repositories.Session
{
    public class ScheduledSessionRepository: BaseRepository, IScheduledSessionRepository
    {
        public ScheduledSessionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ScheduledSession> FindById(int id)
        {
            return await _context.ScheduledSessions.FindAsync(id);
        }

        public async Task<IEnumerable<ScheduledSession>> ListAsync()
        {
            return await _context.ScheduledSessions.ToListAsync();
        }

        public void Remove(ScheduledSession scheduledSession)
        {
            _context.ScheduledSessions.Remove(scheduledSession);
        }
    }
}
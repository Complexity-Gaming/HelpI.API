using System.Collections.Generic;
using System.Linq;
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
            return await _context.ScheduledSessions
                .Include(o => o.Expert)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(ScheduledSession scheduledSession)
        {
             await _context.ScheduledSessions.AddAsync(scheduledSession);
        }

        public async  Task<IEnumerable<ScheduledSession>> ListByPlayerIdAsync(int playerId)
        {
            return await _context.ScheduledSessions
                .Where(p => p.PlayerId == playerId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public async Task<IEnumerable<ScheduledSession>> ListByExpertIdAsync(int expertId)
        {
            return await _context.ScheduledSessions
                .Where(p => p.ExpertId == expertId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public async Task<IEnumerable<ScheduledSession>> FindByPlayerIdAndExpertId(int playerId, int expertId)
        {
            return await _context.ScheduledSessions
                .Where(p => p.ExpertId == expertId && p.PlayerId == playerId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public async Task<IEnumerable<ScheduledSession>> ListAsync()
        {
            return await _context.ScheduledSessions
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public void Remove(ScheduledSession scheduledSession)
        {
            _context.ScheduledSessions.Remove(scheduledSession);
        }
    }
}
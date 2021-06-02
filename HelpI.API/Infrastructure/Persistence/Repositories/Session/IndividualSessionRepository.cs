using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Persistence.Contexts;
using HelpI.API.Domain.Persistence.Repositories.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Infrastructure.Persistence.Repositories.Session
{
    public class IndividualSessionRepository : BaseRepository, IIndividualSessionRepository
    {
        public IndividualSessionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IndividualSession> FindById(int id)
        {
            return await _context.IndividualSessions
                .Include(o => o.Expert)
                .Include(p => p.Player)
                .Include(p=> p.SessionCalification)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(IndividualSession session)
        {
            await _context.IndividualSessions.AddAsync(session);
        }

        public async Task<IEnumerable<IndividualSession>> ListByPlayerIdAsync(int playerId)
        {
            return await _context.IndividualSessions
                .Where(p => p.PlayerId == playerId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public async Task<IEnumerable<IndividualSession>> ListByExpertIdAsync(int expertId)
        {
            return await _context.IndividualSessions
                .Where(p => p.ExpertId == expertId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public async Task<IEnumerable<IndividualSession>> FindByPlayerIdAndExpertId(int playerId, int expertId)
        {
            return await _context.IndividualSessions
                .Where(p => p.ExpertId == expertId && p.PlayerId == playerId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public void Update(IndividualSession session)
        {
            _context.IndividualSessions.Update(session);
        }

        public async Task<IEnumerable<IndividualSession>> ListAsync()
        {
            return await _context.IndividualSessions
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .Include(p=> p.SessionCalification)
                .ToListAsync();
        }

        public void Remove(IndividualSession individualSession)
        {
            _context.IndividualSessions.Remove(individualSession);
        }
    }
}

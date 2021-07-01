using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.SeedWork.Contexts;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Session.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Session.Infrastructure.Persistence.Repositories
{
    public class IndividualSessionRepository : BaseRepository, IIndividualSessionRepository
    {
        public IndividualSessionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CoachingSession> FindById(int id)
        {
            return await _context.IndividualSessions
                .Include(o => o.Expert)
                .Include(p => p.Player)
                .Include(p=> p.SessionReview)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(CoachingSession session)
        {
            await _context.IndividualSessions.AddAsync(session);
        }

        public async Task<IEnumerable<CoachingSession>> ListByPlayerIdAsync(int playerId)
        {
            return await _context.IndividualSessions
                .Where(p => p.PlayerId == playerId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public async Task<IEnumerable<CoachingSession>> ListByExpertIdAsync(int expertId)
        {
            return await _context.IndividualSessions
                .Where(p => p.ExpertId == expertId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public async Task<IEnumerable<CoachingSession>> FindByPlayerIdAndExpertId(int playerId, int expertId)
        {
            return await _context.IndividualSessions
                .Where(p => p.ExpertId == expertId && p.PlayerId == playerId)
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .ToListAsync();
        }

        public void Update(CoachingSession session)
        {
            _context.IndividualSessions.Update(session);
        }

        public async Task<IEnumerable<CoachingSession>> ListAsync()
        {
            return await _context.IndividualSessions
                .Include(p => p.Player)
                .Include(p => p.Expert)
                .Include(p=> p.SessionReview)
                .ToListAsync();
        }

        public void Remove(CoachingSession coachingSession)
        {
            _context.IndividualSessions.Remove(coachingSession);
        }
    }
}

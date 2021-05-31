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
            return await _context.IndividualSessions.FindAsync(id);
        }

        public async Task<IEnumerable<IndividualSession>> ListAsync()
        {
            return await _context.IndividualSessions.ToListAsync();
        }

        public void Remove(IndividualSession individualSession)
        {
            _context.IndividualSessions.Remove(individualSession);
        }
    }
}

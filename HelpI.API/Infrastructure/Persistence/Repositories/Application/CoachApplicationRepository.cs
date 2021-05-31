using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Persistence.Contexts;
using HelpI.API.Domain.Persistence.Repositories.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Infrastructure.Persistence.Repositories.Application
{
    public class CoachApplicationRepository : BaseRepository, ICoachApplicationRepository
    {
        public CoachApplicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CoachApplication> FindById(int id)
        {
            return await _context.CoachApplications.FindAsync(id);
        }

        public async Task<IEnumerable<CoachApplication>> ListAsync()
        {
            return await _context.CoachApplications.ToListAsync();
        }

        public void Remove(CoachApplication coachApplication)
        {
            _context.CoachApplications.Remove(coachApplication);
        }
    }
}

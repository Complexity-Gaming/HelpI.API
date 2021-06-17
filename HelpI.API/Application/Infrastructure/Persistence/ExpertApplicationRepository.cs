using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Application.Domain.Models;
using HelpI.API.Application.Domain.Persistence.Repository;
using HelpI.API.SeedWork.Contexts;
using HelpI.API.SeedWork.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Application.Infrastructure.Persistence
{
    public class ExpertApplicationRepository : BaseRepository, IExpertApplicationRepository
    {
        public ExpertApplicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ExpertApplication> FindById(int id)
        {
           return await _context.ExpertApplications
               .Include(o => o.Player)
               .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<ExpertApplication>> ListByApplicantIdAsync(int applicantId)
        {
            return await _context.ExpertApplications
                .Where(application => application.PlayerId == applicantId)
                .Include(application => application.Player).ToListAsync();
        }

        public async Task AddAsync(ExpertApplication application)
        {
             await _context.ExpertApplications.AddAsync(application);
        }

        public void Update(ExpertApplication application)
        {
            _context.ExpertApplications.Update(application);
        }

        public async Task<IEnumerable<ExpertApplication>> ListAsync()
        {
            return await _context.ExpertApplications.Include(p => p.Player).ToListAsync();
        }

        public void Remove(ExpertApplication expertApplication)
        {
            _context.ExpertApplications.Remove(expertApplication);
        }
    }
}

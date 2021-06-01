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
    public class ExpertApplicationRepository : BaseRepository, IExpertApplicationRepository
    {
        public ExpertApplicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ExpertApplication> FindById(int id)
        {
           return await _context.ExpertApplications
               .Include(o => o.Applicant)
               .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<ExpertApplication>> ListByApplicantIdAsync(int applicantId)
        {
            return await _context.ExpertApplications
                .Where(application => application.PlayerId == applicantId)
                .Include(application => application.Applicant).ToListAsync();
        }

        public void Update(ExpertApplication application)
        {
            _context.ExpertApplications.Update(application);
        }

        public async Task<IEnumerable<ExpertApplication>> ListAsync()
        {
            return await _context.ExpertApplications.Include(p => p.Applicant).ToListAsync();
        }

        public void Remove(ExpertApplication expertApplication)
        {
            _context.ExpertApplications.Remove(expertApplication);
        }
    }
}

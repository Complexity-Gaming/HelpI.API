using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Persistence.Contexts;
using HelpI.API.Domain.Persistence.Repositories.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Infrastructure.Persistence.Repositories.Security
{
    public class ExpertRepository : BaseRepository, IExpertRepository
    {
        public ExpertRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Expert expert)
        {
            await _context.Experts.AddAsync(expert);
        }

        public async Task<Expert> FindById(int id)
        {
            return await _context.Experts.FindAsync(id);
        }

        public async Task<IEnumerable<Expert>> ListAsync()
        {
            return await _context.Experts.ToListAsync();
        }

        public void Remove(Expert expert)
        {
            _context.Experts.Remove(expert);
        }

        public void Update(Expert expert)
        {
            _context.Experts.Update(expert);
        }
    }
}

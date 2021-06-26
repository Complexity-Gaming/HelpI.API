using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Persistence.Repositories;
using HelpI.API.SeedWork.Contexts;
using HelpI.API.SeedWork.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Security.Infrastructure.Repositories
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

        public async Task<int> GetNewIdAsync()
        {
            try
            {
                var expert = await _context.Experts.OrderByDescending(p => p.Id).FirstAsync();
                return expert.Id + 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
        }

        public async Task<IEnumerable<Expert>> FindByGameIdAsync(int gameId)
        {
            return await _context.Experts.Where(p => p.GameId == gameId).ToListAsync();
        }

        public void Update(Expert expert)
        {
            _context.Experts.Update(expert);
        }
    }
}

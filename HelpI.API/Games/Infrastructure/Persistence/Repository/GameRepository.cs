using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Games.Domain.Models;
using HelpI.API.Games.Domain.Persistence.Repository;
using HelpI.API.SeedWork.Contexts;
using HelpI.API.SeedWork.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Games.Infrastructure.Persistence.Repository
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<GameModel>> ListAsync()
        {
            return await _context.Games.IgnoreAutoIncludes().ToListAsync();
        }

        public async Task<GameModel> FindById(int id)
        {
            return await _context.Games.FindAsync(id);
        }
    }
}
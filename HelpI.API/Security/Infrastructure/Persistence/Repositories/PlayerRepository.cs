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
    public class PlayerRepository : BaseRepository, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsync(Player player)
        {
            await _context.Players.AddAsync(player);
        }

        public async Task<Player> FindById(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task<IEnumerable<Player>> ListAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public void Remove(Player player)
        {
            _context.Players.Remove(player);
        }

        public async Task<int> GetNewIdAsync()
        {
            try
            {
                var player = await _context.Players.OrderByDescending(p => p.Id).FirstAsync();
                return player.Id + 1;
            }
            catch (Exception e)
            {
                return 1;
            }
        }

        public void Update(Player player)
        {
            _context.Players.Update(player);
        }
    }
}

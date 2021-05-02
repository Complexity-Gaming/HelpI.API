using HelpI.API.Domain.Models;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> ListAsync();
        Task<PlayerResponse> GetByIdAsync(int id);
        Task<PlayerResponse> SaveAsync(Player player);
        Task<PlayerResponse> UpdateAsync(int id, Player player);
        Task<PlayerResponse> DeleteAsync(int id);
    }
}

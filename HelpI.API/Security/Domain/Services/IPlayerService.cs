using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Services.Communication;

namespace HelpI.API.Security.Domain.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> ListAsync();
        Task<IEnumerable<Player>> ListByTrainingMaterialIdAsync(int trainingMaterialId);
        Task<PlayerResponse> GetByIdAsync(int id);
        Task<PlayerResponse> SaveAsync(Player player);
        Task<PlayerResponse> UpdateAsync(int id, Player player);
        Task<PlayerResponse> DeleteAsync(int id);
    }
}

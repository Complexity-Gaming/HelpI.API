using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Training.Domain.Models;

namespace HelpI.API.Training.Domain.Persistence.Repositories
{
    public interface IPlayerTrainingMaterialRepository
    {
        Task<IEnumerable<PlayerTrainingMaterial>> ListAsync();
        Task<IEnumerable<PlayerTrainingMaterial>> ListByPlayerIdAsync(int playerId);
        Task<IEnumerable<PlayerTrainingMaterial>> ListByTrainingMaterialIdAsync(int trainingMaterialId);
        Task<PlayerTrainingMaterial> FindByPlayerIdAndTrainingMaterialId(int playerId, int trainingMaterialId);
        Task AddAsync(PlayerTrainingMaterial playerTrainingMaterial);
        void Remove(PlayerTrainingMaterial playerTrainingMaterial);
        Task PlayerPurchaseTrainingMaterial(int playerId, int trainingMaterialId);
    }
}

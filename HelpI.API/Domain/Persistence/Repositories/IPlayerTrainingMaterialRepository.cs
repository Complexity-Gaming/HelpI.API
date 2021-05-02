using HelpI.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Persistence.Repositories
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

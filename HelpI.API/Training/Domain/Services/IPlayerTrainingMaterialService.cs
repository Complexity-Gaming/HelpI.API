using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Training.Domain.Models;
using HelpI.API.Training.Domain.Services.Communications;

namespace HelpI.API.Training.Domain.Services
{
    public interface IPlayerTrainingMaterialService
    {
        Task<IEnumerable<PlayerTrainingMaterial>> ListAsync();
        Task<IEnumerable<PlayerTrainingMaterial>> ListByPlayerIdAsync(int playerId);
        Task<IEnumerable<PlayerTrainingMaterial>> ListByTrainingMaterialIdAsync(int trainingMaterialId);
        Task<PlayerTrainingMaterialResponse> PlayerPurchaseTrainingMaterial(int playerId, int trainingMaterialId);
    }
}

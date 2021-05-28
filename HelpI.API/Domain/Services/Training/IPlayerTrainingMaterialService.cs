using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Training;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services
{
    public interface IPlayerTrainingMaterialService
    {
        Task<IEnumerable<PlayerTrainingMaterial>> ListAsync();
        Task<IEnumerable<PlayerTrainingMaterial>> ListByPlayerIdAsync(int playerId);
        Task<IEnumerable<PlayerTrainingMaterial>> ListByTrainingMaterialIdAsync(int trainingMaterialId);
        Task<PlayerTrainingMaterialResponse> PlayerPurchaseTrainingMaterial(int playerId, int trainingMaterialId);
    }
}

using HelpI.API.Domain.Models;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services
{
    public interface ITrainingMaterialService
    {
        Task<IEnumerable<TrainingMaterial>> ListAsync();
        Task<IEnumerable<TrainingMaterial>> ListByExpertIdAsync(int expertId);
        Task<IEnumerable<TrainingMaterial>> ListByPlayerIdAsync(int playerId);
        Task<TrainingMaterialResponse> GetByIdAsync(int id);
        Task<TrainingMaterialResponse> UpdateAsync(int id, TrainingMaterial trainingMaterial);
        Task<TrainingMaterialResponse> PublishTrainingMaterialAsync(int expertId, TrainingMaterial trainingMaterial);
    }
}

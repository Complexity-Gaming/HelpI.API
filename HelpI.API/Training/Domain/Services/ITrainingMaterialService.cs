using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Training.Domain.Models;
using HelpI.API.Training.Domain.Services.Communications;

namespace HelpI.API.Training.Domain.Services
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

using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Training.Domain.Models;

namespace HelpI.API.Training.Domain.Persistence.Repositories
{
    public interface ITrainingMaterialRepository
    {
        Task<IEnumerable<TrainingMaterial>> ListAsync();
        Task<TrainingMaterial> FindByIdAsync(int id);
        Task<IEnumerable<TrainingMaterial>> ListByExpertIdAsync(int expertId);
        Task<int> GetNewIdAsync();
        Task<IEnumerable<TrainingMaterial>> FindByGameIdAsync(int gameId);
    }
}

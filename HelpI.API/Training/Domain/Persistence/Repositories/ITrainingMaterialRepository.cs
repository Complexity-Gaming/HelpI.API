using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Training.Domain.Models;

namespace HelpI.API.Training.Domain.Persistence.Repositories
{
    public interface ITrainingMaterialRepository
    {
        Task<IEnumerable<TrainingMaterial>> ListAsync();
        Task<IEnumerable<TrainingMaterial>> ListByExpertIdAsync(int expertId);
        Task<int> GetNewIdAsync();
    }
}

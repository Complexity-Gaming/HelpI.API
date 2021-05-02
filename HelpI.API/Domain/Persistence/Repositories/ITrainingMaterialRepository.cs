using HelpI.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Persistence.Repositories
{
    public interface ITrainingMaterialRepository
    {
        Task<IEnumerable<TrainingMaterial>> ListAsync();
        Task<IEnumerable<TrainingMaterial>> ListByExpertIdAsync(int expertId);
        Task AddAsync(TrainingMaterial trainingMaterial);
    }
}

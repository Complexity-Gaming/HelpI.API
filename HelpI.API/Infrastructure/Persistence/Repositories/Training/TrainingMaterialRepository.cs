using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Training;
using HelpI.API.Domain.Persistence.Contexts;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Persistence.Repositories.Training;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Infrastructure.Persistence.Repositories.Training
{
    public class TrainingMaterialRepository : BaseRepository, ITrainingMaterialRepository
    {
        public TrainingMaterialRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(TrainingMaterial trainingMaterial)
        {
            await _context.TrainingMaterials.AddAsync(trainingMaterial);
        }

        public async Task<IEnumerable<TrainingMaterial>> ListAsync()
        {
            return await _context.TrainingMaterials.Include(p => p.CreatedBy).ToListAsync();
        }

        public async Task<IEnumerable<TrainingMaterial>> ListByExpertIdAsync(int expertId)
        {
            return await _context.TrainingMaterials
                .Where(p => p.ExpertId == expertId)
                .Include(p => p.CreatedBy)
                .ToListAsync();
        }
    }
}

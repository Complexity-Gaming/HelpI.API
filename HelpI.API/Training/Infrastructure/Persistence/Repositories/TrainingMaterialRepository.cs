﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.SeedWork.Contexts;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.Training.Domain.Models;
using HelpI.API.Training.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Training.Infrastructure.Persistence.Repositories
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
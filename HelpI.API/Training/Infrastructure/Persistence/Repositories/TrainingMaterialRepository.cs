using System;
using System.Collections.Generic;
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

        public async Task<TrainingMaterial> FindByIdAsync(int id)
        {
            return await _context.TrainingMaterials.Include(p => p.CreatedBy).Where(p => p.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<TrainingMaterial>> ListByExpertIdAsync(int expertId)
        {
            return await _context.TrainingMaterials
                .Where(p => p.ExpertId == expertId)
                .Include(p => p.CreatedBy)
                .ToListAsync();
        }

        public async Task<int> GetNewIdAsync()
        {
            try
            {
                var training = await _context.TrainingMaterials.OrderByDescending(p => p.Id).FirstAsync();
                return training.Id + 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
        }

        public async Task<IEnumerable<TrainingMaterial>> FindByGameIdAsync(int gameId)
        {
            return await _context.TrainingMaterials.Where(p => p.GameId == gameId).Include(p => p.CreatedBy)
                .ToListAsync();
        }
    }
}

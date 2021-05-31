﻿using HelpI.API.Domain.Models;
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
    public class PlayerTrainingMaterialRepository : BaseRepository, IPlayerTrainingMaterialRepository
    {
        public PlayerTrainingMaterialRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(PlayerTrainingMaterial playerTrainingMaterial)
        {
            await _context.PlayerTrainingMaterials.AddAsync(playerTrainingMaterial);
        }

        public async Task<PlayerTrainingMaterial> FindByPlayerIdAndTrainingMaterialId(int playerId, int trainingMaterialId)
        {
            return await _context.PlayerTrainingMaterials.FindAsync(playerId, trainingMaterialId);
        }

        public async Task<IEnumerable<PlayerTrainingMaterial>> ListAsync()
        {
            return await _context.PlayerTrainingMaterials
                .Include(pt => pt.Player)
                .Include(pt => pt.TrainingMaterial)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerTrainingMaterial>> ListByPlayerIdAsync(int playerId)
        {
            return await _context.PlayerTrainingMaterials
                .Where(pt => pt.PlayerId == playerId)
                .Include(pt => pt.Player)
                .Include(pt => pt.TrainingMaterial).ThenInclude(pt => pt.CreatedBy)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerTrainingMaterial>> ListByTrainingMaterialIdAsync(int trainingMaterialId)
        {
            return await _context.PlayerTrainingMaterials
                .Where(pt => pt.TrainingMaterialId == trainingMaterialId)
                .Include(pt => pt.Player)
                .Include(pt => pt.TrainingMaterial)
                .ToListAsync();
        }

        public async Task PlayerPurchaseTrainingMaterial(int playerId, int trainingMaterialId)
        {
            PlayerTrainingMaterial playerTrainingMaterial = await FindByPlayerIdAndTrainingMaterialId(playerId, trainingMaterialId);
            if (playerTrainingMaterial == null)
            {
                playerTrainingMaterial = new PlayerTrainingMaterial { PlayerId = playerId, TrainingMaterialId = trainingMaterialId};
                await AddAsync(playerTrainingMaterial);
            }
        }

        public void Remove(PlayerTrainingMaterial playerTrainingMaterial)
        {
            _context.Remove(playerTrainingMaterial);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.Training.Domain.Models;
using HelpI.API.Training.Domain.Persistence.Repositories;
using HelpI.API.Training.Domain.Services;
using HelpI.API.Training.Domain.Services.Communications;

namespace HelpI.API.Training.Application.Services
{
    public class PlayerTrainingMaterialService : IPlayerTrainingMaterialService
    {
        private readonly IPlayerTrainingMaterialRepository _playerTrainingMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlayerTrainingMaterialService(IPlayerTrainingMaterialRepository playerTrainingMaterialRepository, IUnitOfWork unitOfWork)
        {
            _playerTrainingMaterialRepository = playerTrainingMaterialRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<PlayerTrainingMaterial>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlayerTrainingMaterial>> ListByPlayerIdAsync(int playerId)
        {
            return await _playerTrainingMaterialRepository.ListByPlayerIdAsync(playerId);
        }

        public async Task<IEnumerable<PlayerTrainingMaterial>> ListByTrainingMaterialIdAsync(int trainingMaterialId)
        {
            return await _playerTrainingMaterialRepository.ListByTrainingMaterialIdAsync(trainingMaterialId);
        }

        public async Task<PlayerTrainingMaterialResponse> PlayerPurchaseTrainingMaterial(int playerId, int trainingMaterialId)
        {
            try
            {
                await _playerTrainingMaterialRepository.PlayerPurchaseTrainingMaterial(playerId, trainingMaterialId);
                await _unitOfWork.CompleteAsync();
                PlayerTrainingMaterial playerTrainingMaterial = await _playerTrainingMaterialRepository
                    .FindByPlayerIdAndTrainingMaterialId(playerId, trainingMaterialId);
                return new PlayerTrainingMaterialResponse(playerTrainingMaterial);
            }
            catch (Exception ex)
            {
                return new PlayerTrainingMaterialResponse($"An Error accurred while purchasing the training material: { ex.Message }");
            }
        }
    }
}

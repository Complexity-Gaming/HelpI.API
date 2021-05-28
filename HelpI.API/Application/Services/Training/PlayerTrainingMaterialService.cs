using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Training;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Persistence.Repositories.Training;
using HelpI.API.Domain.Services;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Services.Training
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
                return new PlayerTrainingMaterialResponse($"An Error acurred while purchasing the training material: { ex.Message }");
            }
        }
    }
}

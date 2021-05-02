using HelpI.API.Domain.Models;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Services;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Services
{
    public class TrainingMaterialService : ITrainingMaterialService
    {
        private readonly ITrainingMaterialRepository _trainingMaterialRepository;
        private readonly IExpertRepository _expertRepository;
        private readonly IPlayerTrainingMaterialRepository _playerTrainingMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainingMaterialService(ITrainingMaterialRepository trainingMaterialRepository, IUnitOfWork unitOfWork, IExpertRepository expertRepository, IPlayerTrainingMaterialRepository playerTrainingMaterialRepository)
        {
            _trainingMaterialRepository = trainingMaterialRepository;
            _unitOfWork = unitOfWork;
            _expertRepository = expertRepository;
            _playerTrainingMaterialRepository = playerTrainingMaterialRepository;
        }

        public Task<TrainingMaterialResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrainingMaterial>> ListAsync()
        {
            return await _trainingMaterialRepository.ListAsync();
        }

        public async Task<IEnumerable<TrainingMaterial>> ListByExpertIdAsync(int expertId)
        {
            return await _trainingMaterialRepository.ListByExpertIdAsync(expertId);
        }

        public async Task<IEnumerable<TrainingMaterial>> ListByPlayerIdAsync(int playerId)
        {
            var playerTrainingMaterials = await _playerTrainingMaterialRepository.ListByPlayerIdAsync(playerId);
            var trainingMaterials = playerTrainingMaterials.Select(pt => pt.TrainingMaterial).ToList();
            return trainingMaterials;
        }

        public async Task<TrainingMaterialResponse> PublishTrainingMaterialAsync(int expertId, TrainingMaterial trainingMaterial)
        {
            try
            {
                var existingExpert = await _expertRepository.FindById(expertId);
                if (existingExpert == null)
                    return new TrainingMaterialResponse("Expert Not Found");

                existingExpert.TrainingMaterials.Add(trainingMaterial);                
                await _unitOfWork.CompleteAsync();
                return new TrainingMaterialResponse(trainingMaterial);
            }
            catch (Exception ex)
            {
                return new TrainingMaterialResponse($"An error ocurred while uploading Training Material: {ex.Message}");
            }
        }

        public Task<TrainingMaterialResponse> UpdateAsync(int id, TrainingMaterial trainingMaterial)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerTrainingMaterialRepository _playerTrainingMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IPlayerRepository playerRepository, IUnitOfWork unitOfWork, IPlayerTrainingMaterialRepository playerTrainingMaterialRepository)
        {
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
            _playerTrainingMaterialRepository = playerTrainingMaterialRepository;
        }

        public async Task<PlayerResponse> DeleteAsync(int id)
        {
            var existingPlayer = await _playerRepository.FindById(id);

            if (existingPlayer == null)
                return new PlayerResponse("Player not found");

            try
            {
                _playerRepository.Remove(existingPlayer);
                await _unitOfWork.CompleteAsync();

                return new PlayerResponse(existingPlayer);
            }
            catch(Exception ex)
            {
                return new PlayerResponse($"An error ocurred while deleting player: {ex.Message}");
            }

        }

        public async Task<PlayerResponse> GetByIdAsync(int id)
        {
            var existingPlayer = await _playerRepository.FindById(id);

            if (existingPlayer == null)
                return new PlayerResponse("Player not found");
            return new PlayerResponse(existingPlayer);
        }

        public async Task<IEnumerable<Player>> ListAsync()
        {
            return await _playerRepository.ListAsync(); 
        }

        public async Task<IEnumerable<Player>> ListByTrainingMaterialIdAsync(int trainingMaterialId)
        {
            var playerTrainingMaterials = await _playerTrainingMaterialRepository.ListByTrainingMaterialIdAsync(trainingMaterialId);
            var players = playerTrainingMaterials.Select(pt => pt.Player).ToList();
            return players;
        }

        public async Task<PlayerResponse> SaveAsync(Player player)
        {
            try
            {
                await _playerRepository.AddAsync(player);
                await _unitOfWork.CompleteAsync();

                return new PlayerResponse(player);
            }
            catch(Exception ex)
            {
                return new PlayerResponse($"An error ocurred while saving player: {ex.Message}");
            }
        }

        public async Task<PlayerResponse> UpdateAsync(int id, Player player)
        {
            var existingPlayer = await _playerRepository.FindById(id);

            if (existingPlayer == null)
                return new PlayerResponse("Player not found");

            try
            {
                _playerRepository.Update(existingPlayer);
                await _unitOfWork.CompleteAsync();

                return new PlayerResponse(existingPlayer);
            }
            catch (Exception ex)
            {
                return new PlayerResponse($"An error ocurred while deleting player: {ex.Message}");
            }
        }
    }
}

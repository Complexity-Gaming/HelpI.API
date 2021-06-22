using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Application.Domain.Models;
using HelpI.API.Application.Domain.Persistence.Repository;
using HelpI.API.Application.Domain.Services;
using HelpI.API.Application.Domain.Services.Communications;
using HelpI.API.Games.Domain.Persistence.Repository;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Persistence.Repositories;
using HelpI.API.Security.Domain.Services.Communication;
using HelpI.API.SeedWork.Extensions;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.Training.Domain.Persistence.Repositories;

namespace HelpI.API.Application.Application.Services
{
    public class ExpertApplicationService : IExpertApplicationService
    {
        private readonly IExpertApplicationRepository _expertApplicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerRepository _playerRepository;
        private readonly IExpertRepository _expertRepository;
        private readonly IGameRepository _gameRepository;

        public ExpertApplicationService(IExpertApplicationRepository expertApplicationRepository, IUnitOfWork unitOfWork, IPlayerRepository playerRepository, IExpertRepository expertRepository, IGameRepository gameRepository)
        {
            this._expertApplicationRepository = expertApplicationRepository;
            this._unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
            _expertRepository = expertRepository;
            _gameRepository = gameRepository;
        }
        public async Task<ExpertApplicationResponse> SendExpertApplication(int playerId, ExpertApplication expertApplication)
        {
            try
            {
                var existingPlayer = await _playerRepository.FindById(playerId);
                if (existingPlayer == null)
                    return new ExpertApplicationResponse("Player Not Found");
                expertApplication.Id = await _expertApplicationRepository.GetNewIdAsync();
                existingPlayer.AddApplication(expertApplication);
                await _expertApplicationRepository.AddAsync(expertApplication);
                await _unitOfWork.CompleteAsync();
                return new ExpertApplicationResponse(expertApplication);
            }
            catch (Exception ex)
            {
                return new ExpertApplicationResponse($"An error occurred while uploading ExpertApplication: {ex.Message}");
            }
        }

        public async Task<ExpertResponse> ReviewApplicationAsync(int id, string review, string reviewComment)
        {
            var existingApplication = await _expertApplicationRepository.FindById(id);
            if (existingApplication == null)
                return new ExpertResponse("Application not found");
            
            switch (existingApplication.ApplicationForm.Status)
            {
                case EApplicationStatus.Rejected:
                    return new ExpertResponse("Application has already been rejected");
                case EApplicationStatus.Passed:
                    return new ExpertResponse("Application has already been accepted");
            }
            
            var player = await _playerRepository.FindById(existingApplication.PlayerId);
            if (player == null)
                return new ExpertResponse($"Player not found with id: {existingApplication.PlayerId}");
            
            try
            {
                EApplicationStatus reviewStatus = review.GetValueFromDescription<EApplicationStatus>();
                if (reviewStatus != EApplicationStatus.Passed)
                {
                    _expertApplicationRepository.Update(existingApplication);
                    await _unitOfWork.CompleteAsync();
                    return new ExpertResponse("The application has been rejected");
                }
                var applicationDetails = existingApplication.ApplicationForm;
                existingApplication.SetApplicationForm(applicationDetails, reviewStatus, reviewComment);
                _expertApplicationRepository.Update(existingApplication);
                var newExpert = new Expert(player);
                var game = await _gameRepository.FindById(existingApplication.GameId);
                newExpert.SetGame(game);
                _playerRepository.Remove(player);
                await _expertRepository.AddAsync(newExpert);
                await _unitOfWork.CompleteAsync();
                return new ExpertResponse(newExpert);
            }
            catch(Exception ex)
            {
                return new ExpertResponse($"An error occurred while Reviewing The Application: {ex.Message}");
            }
        }

        public async Task<ExpertApplicationResponse> DeleteAsync(int id)
        {
            var existingApplication = await _expertApplicationRepository.FindById(id);
            if (existingApplication == null)
            {
                return new ExpertApplicationResponse("Application not found");
            }

            try
            {
                _expertApplicationRepository.Remove(existingApplication);
                await _unitOfWork.CompleteAsync();
                return new ExpertApplicationResponse(existingApplication);
            }
            catch(Exception ex)
            {
                return new ExpertApplicationResponse($"An error occurred while saving Application: {ex.Message}");
            }
        }

        public async Task<ExpertApplicationResponse> GetByIdAsync(int id)
        {
            var existingApplication = await _expertApplicationRepository.FindById(id);
            if (existingApplication == null)
            {
                return new ExpertApplicationResponse("Application not found");
            }
            return new ExpertApplicationResponse(existingApplication);
        }

        public async Task<IEnumerable<ExpertApplication>> ListByApplicantIdAsync(int playerId)
        {
            return await _expertApplicationRepository.ListByApplicantIdAsync(playerId);
        }

        public async Task<IEnumerable<ExpertApplication>> ListAsync()
        {
            return await _expertApplicationRepository.ListAsync();
        }
    }
}

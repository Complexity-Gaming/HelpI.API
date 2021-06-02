using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Persistence.Repositories.Security;
using HelpI.API.Domain.Persistence.Repositories.Session;
using HelpI.API.Domain.Services.Communications;
using HelpI.API.Domain.Services.Session;
using Microsoft.VisualBasic;

namespace HelpI.API.Application.Services.Session
{
    public class ScheduledSessionService : IScheduledSessionService
    {
        private readonly IScheduledSessionRepository _scheduledSessionRepository;
        private readonly IExpertRepository _expertRepository;
        private readonly IPlayerRepository _playerRepository;
        
        private readonly IUnitOfWork _unitOfWork;

        public ScheduledSessionService(IScheduledSessionRepository scheduledSessionRepository, IUnitOfWork unitOfWork, IExpertRepository expertRepository, IPlayerRepository playerRepository)
        {
            _scheduledSessionRepository = scheduledSessionRepository;
            _unitOfWork = unitOfWork;
            _expertRepository = expertRepository;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<ScheduledSession>> ListByPlayerIdAndExpertId(int playerId, int expertId)
        {
            return await _scheduledSessionRepository.FindByPlayerIdAndExpertId(playerId, expertId);
        }

        public async Task<ScheduledSessionResponse> ScheduleSession(ScheduledSession scheduledSession)
        {
            var existingPlayer = await _playerRepository.FindById(scheduledSession.PlayerId);
            if (existingPlayer == null)
                return new ScheduledSessionResponse($"Player not found with id: {scheduledSession.PlayerId}");
            
            var existingExpert = await _expertRepository.FindById(scheduledSession.ExpertId);
            if (existingExpert == null)
                return new ScheduledSessionResponse($"Expert not found with id: {scheduledSession.ExpertId}");

            try
            {
                await _scheduledSessionRepository.AddAsync(scheduledSession);
                await _unitOfWork.CompleteAsync();
                return new ScheduledSessionResponse(scheduledSession);
            }
            catch (Exception ex)
            {
                return new ScheduledSessionResponse($"An error occurred while scheduling the session: {ex.Message}");
            }
        }

        public async Task<ScheduledSessionResponse> DeleteAsync(int id)
        {
            var existingScheduledSession = await _scheduledSessionRepository.FindById(id);

            if (existingScheduledSession == null)
                return new ScheduledSessionResponse("ScheduledSession Not Found");

            try
            {
                _scheduledSessionRepository.Remove(existingScheduledSession);
                await _unitOfWork.CompleteAsync();
                return new ScheduledSessionResponse(existingScheduledSession);
            }
            catch (Exception ex)
            {
                return new ScheduledSessionResponse($"An error occurred while saving ScheduledSession: {ex.Message}");
            }
        }

        public async Task<ScheduledSessionResponse> GetByIdAsync(int id)
        {
            var existingScheduledSession = await _scheduledSessionRepository.FindById(id);
            if (existingScheduledSession == null)
                return new ScheduledSessionResponse("ScheduledSession Not Found");
            return new ScheduledSessionResponse(existingScheduledSession);
        }

        public async Task<IEnumerable<ScheduledSession>> ListByExpertIdAsync(int expertId)
        {
            return await _scheduledSessionRepository.ListByExpertIdAsync(expertId);
        }

        public async Task<IEnumerable<ScheduledSession>> ListByPlayerIdAsync(int playerId)
        {
            return await _scheduledSessionRepository.ListByPlayerIdAsync(playerId);
        }

        public async Task<IEnumerable<ScheduledSession>> ListAsync()
        {
            return await _scheduledSessionRepository.ListAsync();
        }
    }
}
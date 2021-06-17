using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Session.Domain.Repositories;
using HelpI.API.Session.Domain.Services;
using HelpI.API.Session.Domain.Services.Communications;

namespace HelpI.API.Session.Application.Services
{
    public class IndividualSessionService : IIndividualSessionService
    {
        private readonly IIndividualSessionRepository _individualSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IndividualSessionService(IIndividualSessionRepository individualSessionRepository, IUnitOfWork unitOfWork)
        {
            _individualSessionRepository = individualSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IndividualSessionResponse> StartSession(int scheduledSessionId)
        {
            return null;
        }
        public async Task<IndividualSessionResponse> EndSession(int sessionId, SessionCalification calification)
        {
            var session = _individualSessionRepository.FindById(sessionId).Result;
            if(session == null)
                return new IndividualSessionResponse("IndividualSession Not Found");
            
            try
            {
                session.SessionCalification = calification;
                _individualSessionRepository.Update(session);
                await _unitOfWork.CompleteAsync();
                return new IndividualSessionResponse(session);
            }
            catch (Exception ex)
            {
                return new IndividualSessionResponse($"An error occurred while starting the session: {ex.Message}");
            }
        }

        public async Task<IndividualSessionResponse> DeleteAsync(int id)
        {
            var existingIndividualSession = await _individualSessionRepository.FindById(id);

            if (existingIndividualSession == null)
                return new IndividualSessionResponse("IndividualSession Not Found");

            try
            {
                _individualSessionRepository.Remove(existingIndividualSession);
                await _unitOfWork.CompleteAsync();
                return new IndividualSessionResponse(existingIndividualSession);
            }
            catch (Exception ex)
            {
                return new IndividualSessionResponse($"An error occurred while saving IndividualSession: {ex.Message}");
            }
        }

        public async Task<IndividualSessionResponse> GetByIdAsync(int id)
        {
            var existingIndividualSession = await _individualSessionRepository.FindById(id);
            if (existingIndividualSession == null)
                return new IndividualSessionResponse("IndividualSession Not Found");
            return new IndividualSessionResponse(existingIndividualSession);
        }

        public async Task<IEnumerable<IndividualSession>> ListByExpertIdAsync(int expertId)
        {
            return await _individualSessionRepository.ListByExpertIdAsync(expertId);
        }

        public async Task<IEnumerable<IndividualSession>> ListByPlayerIdAsync(int playerId)
        {
            return await _individualSessionRepository.ListByPlayerIdAsync(playerId);
        }

        public async Task<IEnumerable<IndividualSession>> ListByPlayerIdAndExpertId(int playerId, int expertId)
        {
            return await _individualSessionRepository.FindByPlayerIdAndExpertId(playerId, expertId);
        }

        public async Task<IEnumerable<IndividualSession>> ListAsync()
        {
            return await _individualSessionRepository.ListAsync();
        }
    }
}

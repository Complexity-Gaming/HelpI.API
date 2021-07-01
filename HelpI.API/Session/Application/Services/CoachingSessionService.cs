using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Session.Domain.Persistence.Repositories;
using HelpI.API.Session.Domain.Services;
using HelpI.API.Session.Domain.Services.Communications;

namespace HelpI.API.Session.Application.Services
{
    public class CoachingSessionService : ICoachingSessionService
    {
        private readonly IIndividualSessionRepository _individualSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CoachingSessionService(IIndividualSessionRepository individualSessionRepository, IUnitOfWork unitOfWork)
        {
            _individualSessionRepository = individualSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<CoachingSessionResponse> StartSession(int scheduledSessionId)
        {
            return null;
        }
        public async Task<CoachingSessionResponse> EndSession(int sessionId, SessionReview review)
        {
            var session = _individualSessionRepository.FindById(sessionId).Result;
            if(session == null)
                return new CoachingSessionResponse("CoachingSession Not Found");
            
            try
            {
                session.SessionReview = review;
                _individualSessionRepository.Update(session);
                await _unitOfWork.CompleteAsync();
                return new CoachingSessionResponse(session);
            }
            catch (Exception ex)
            {
                return new CoachingSessionResponse($"An error occurred while starting the session: {ex.Message}");
            }
        }

        public async Task<CoachingSessionResponse> DeleteAsync(int id)
        {
            var existingIndividualSession = await _individualSessionRepository.FindById(id);

            if (existingIndividualSession == null)
                return new CoachingSessionResponse("CoachingSession Not Found");

            try
            {
                _individualSessionRepository.Remove(existingIndividualSession);
                await _unitOfWork.CompleteAsync();
                return new CoachingSessionResponse(existingIndividualSession);
            }
            catch (Exception ex)
            {
                return new CoachingSessionResponse($"An error occurred while saving CoachingSession: {ex.Message}");
            }
        }

        public async Task<CoachingSessionResponse> GetByIdAsync(int id)
        {
            var existingIndividualSession = await _individualSessionRepository.FindById(id);
            if (existingIndividualSession == null)
                return new CoachingSessionResponse("CoachingSession Not Found");
            return new CoachingSessionResponse(existingIndividualSession);
        }

        public async Task<IEnumerable<CoachingSession>> ListByExpertIdAsync(int expertId)
        {
            return await _individualSessionRepository.ListByExpertIdAsync(expertId);
        }

        public async Task<IEnumerable<CoachingSession>> ListByPlayerIdAsync(int playerId)
        {
            return await _individualSessionRepository.ListByPlayerIdAsync(playerId);
        }

        public async Task<IEnumerable<CoachingSession>> ListByPlayerIdAndExpertId(int playerId, int expertId)
        {
            return await _individualSessionRepository.FindByPlayerIdAndExpertId(playerId, expertId);
        }

        public async Task<IEnumerable<CoachingSession>> ListAsync()
        {
            return await _individualSessionRepository.ListAsync();
        }
    }
}

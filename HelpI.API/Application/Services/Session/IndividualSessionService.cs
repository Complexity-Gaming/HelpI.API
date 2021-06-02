using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Persistence.Repositories.Session;
using HelpI.API.Domain.Services.Communications;
using HelpI.API.Domain.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Engines;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HelpI.API.Application.Services.Session
{
    public class IndividualSessionService : IIndividualSessionService
    {
        private readonly IIndividualSessionRepository _individualSessionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IScheduledSessionRepository _scheduledSessionRepository;

        public IndividualSessionService(IIndividualSessionRepository individualSessionRepository, IUnitOfWork unitOfWork, IScheduledSessionRepository scheduledSessionRepository)
        {
            _individualSessionRepository = individualSessionRepository;
            _unitOfWork = unitOfWork;
            _scheduledSessionRepository = scheduledSessionRepository;
        }

        public async Task<IndividualSessionResponse> StartSession(int scheduledSessionId)
        {
            var scheduledSession = _scheduledSessionRepository.FindById(scheduledSessionId).Result;
            if(scheduledSession == null)
                return new IndividualSessionResponse("IndividualSession Not Found");
            
            try
            {
                var newSession = new IndividualSession(scheduledSession.ScheduledSessionId.ScheduledSessionId,
                    scheduledSession.SessionDate, scheduledSession.PlayerId, scheduledSession.ExpertId, scheduledSession.Price);
                await _individualSessionRepository.AddAsync(newSession);
                await _unitOfWork.CompleteAsync();
                return new IndividualSessionResponse(newSession);
            }
            catch (Exception ex)
            {
                return new IndividualSessionResponse($"An error occurred while starting the session: {ex.Message}");
            }
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

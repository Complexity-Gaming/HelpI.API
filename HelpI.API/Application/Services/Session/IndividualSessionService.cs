using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Persistence.Repositories.Session;
using HelpI.API.Domain.Services.Communications;
using HelpI.API.Domain.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Services.Session
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
                return new IndividualSessionResponse($"An error ocurred while saving IndividualSession: {ex.Message}");
            }
        }

        public async Task<IndividualSessionResponse> GetByIdAsync(int id)
        {
            var existingIndividualSession = await _individualSessionRepository.FindById(id);
            if (existingIndividualSession == null)
                return new IndividualSessionResponse("IndividualSession Not Found");
            return new IndividualSessionResponse(existingIndividualSession);
        }

        public async Task<IEnumerable<IndividualSession>> ListAsync()
        {
            return await _individualSessionRepository.ListAsync();
        }
    }
}

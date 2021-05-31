using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Persistence.Repositories.Application;
using HelpI.API.Domain.Services.Application;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Application.Services.Application
{
    public class CoachApplicationService : ICoachApplicationService
    {
        private readonly ICoachApplicationRepository _coachApplicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CoachApplicationService(ICoachApplicationRepository coachApplicationRepository, IUnitOfWork unitOfWork)
        {
            this._coachApplicationRepository = coachApplicationRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<CoachApplicationRespose> DeleteAsync(int id)
        {
            var existingApplication = await _coachApplicationRepository.FindById(id);
            if (existingApplication == null)
            {
                return new CoachApplicationRespose("Application not found");
            }

            try
            {
                _coachApplicationRepository.Remove(existingApplication);
                await _unitOfWork.CompleteAsync();
                return new CoachApplicationRespose(existingApplication);
            }
            catch(Exception ex)
            {
                return new CoachApplicationRespose($"An error ocurred while saving Application: {ex.Message}");
            }
        }

        public async Task<CoachApplicationRespose> GetByIdAsync(int id)
        {
            var existingApplication = await _coachApplicationRepository.FindById(id);
            if (existingApplication == null)
            {
                return new CoachApplicationRespose("Application not found");
            }
            return new CoachApplicationRespose(existingApplication);
        }

        public async Task<IEnumerable<CoachApplication>> ListAsync()
        {
            return await _coachApplicationRepository.ListAsync();
        }
    }
}

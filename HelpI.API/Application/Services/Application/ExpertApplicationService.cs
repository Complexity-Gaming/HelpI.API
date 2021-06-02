using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Persistence.Repositories.Application;
using HelpI.API.Domain.Services.Application;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Application.Extensions;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Persistence.Repositories.Security;

namespace HelpI.API.Application.Services.Application
{
    public class ExpertApplicationService : IExpertApplicationService
    {
        private readonly IExpertApplicationRepository _expertApplicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerRepository _playerRepository;
        private readonly IExpertRepository _expertRepository;

        public ExpertApplicationService(IExpertApplicationRepository expertApplicationRepository, IUnitOfWork unitOfWork, IPlayerRepository playerRepository, IExpertRepository expertRepository)
        {
            this._expertApplicationRepository = expertApplicationRepository;
            this._unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
            _expertRepository = expertRepository;
        }
        public async Task<ExpertApplicationResponse> SendExpertApplication(int applicantId, ExpertApplication expertApplication)
        {
            try
            {
                var existingApplicant = await _playerRepository.FindById(applicantId);
                if (existingApplicant == null)
                    return new ExpertApplicationResponse("Applicant Not Found");
                existingApplicant.ExpertApplications.Add(expertApplication);                
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
            
            switch (existingApplication.ApplicationDetails.Status)
            {
                case EApplicationStatus.Rejected:
                    return new ExpertResponse("Application has already been rejected");
                case EApplicationStatus.Passed:
                    return new ExpertResponse("Application has already been accepted");
            }
            try
            {
                var player = await _playerRepository.FindById(existingApplication.PlayerId);
                if (player == null)
                {
                    return new ExpertResponse($"Player not found with id: {existingApplication.PlayerId}");
                }
                var applicationDetails = existingApplication.ApplicationDetails;
                var reviewStatus = review.GetValueFromDescription<EApplicationStatus>();
                existingApplication.ApplicationDetails = new ApplicationDetail(applicationDetails.Description,
                    applicationDetails.VideoApplication, reviewStatus, reviewComment);
                
                if (reviewStatus == EApplicationStatus.Passed)
                {
                    _expertApplicationRepository.Update(existingApplication);
                    var newExpert = new Expert(player);
                    await _expertRepository.AddAsync(newExpert);
                    _playerRepository.Remove(player);
                    await _unitOfWork.CompleteAsync();
                    return new ExpertResponse(newExpert);
                }
                
                _expertApplicationRepository.Update(existingApplication);
                await _unitOfWork.CompleteAsync();
                return new ExpertResponse("The application has been rejected");
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

        public async Task<IEnumerable<ExpertApplication>> ListByApplicantIdAsync(int applicantId)
        {
            return await _expertApplicationRepository.ListByApplicantIdAsync(applicantId);
        }

        public async Task<IEnumerable<ExpertApplication>> ListAsync()
        {
            return await _expertApplicationRepository.ListAsync();
        }
    }
}

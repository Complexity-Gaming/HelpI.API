using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Persistence.Repositories;
using HelpI.API.Security.Domain.Services;
using HelpI.API.Security.Domain.Services.Communication;
using HelpI.API.SeedWork.Repositories;

namespace HelpI.API.Security.Application.Services
{
    public class ExpertService : IExpertService
    {
        private readonly IExpertRepository _expertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExpertService(IUnitOfWork unitOfWork, IExpertRepository expertRepository)
        {
            _unitOfWork = unitOfWork;
            _expertRepository = expertRepository;
        }

        public async Task<ExpertResponse> DeleteAsync(int id)
        {
            var existingExpert = await _expertRepository.FindById(id);

            if (existingExpert == null)
                return new ExpertResponse("Expert Not Found");

            try
            {
                _expertRepository.Remove(existingExpert);
                await _unitOfWork.CompleteAsync();
                return new ExpertResponse(existingExpert);
            }
            catch (Exception ex)
            {
                return new ExpertResponse($"An error ocurred while saving Expert: {ex.Message}");
            }
        }

        public async Task<ExpertResponse> GetByIdAsync(int id)
        {
            var existingExpert = await _expertRepository.FindById(id);
            if (existingExpert == null)
                return new ExpertResponse("Expert Not Found");
            return new ExpertResponse(existingExpert);
        }

        public async Task<IEnumerable<Expert>> ListAsync()
        {
            return await _expertRepository.ListAsync();
        }

        public async Task<ExpertResponse> SaveAsync(Expert expert)
        {
            try
            {
                await _expertRepository.AddAsync(expert);
                await _unitOfWork.CompleteAsync();
                return new ExpertResponse(expert);
            }
            catch (Exception ex)
            {
                return new ExpertResponse($"An error ocurred while saving Expert: {ex.Message}");
            }
        }

        public async Task<ExpertResponse> UpdateAsync(int id, Expert expert)
        {
            var existingExpert = await _expertRepository.FindById(id);
            if (existingExpert == null)
                return new ExpertResponse("Expert Not Found");

            existingExpert.Email = expert.Email;

            try
            {
                _expertRepository.Update(existingExpert);
                await _unitOfWork.CompleteAsync();
                return new ExpertResponse(existingExpert);
            }
            catch (Exception ex)
            {
                return new ExpertResponse($"An Error ocurred while updating Expert: {ex.Message}");
            }
        }
    }
}

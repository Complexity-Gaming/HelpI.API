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

            existingExpert.Name = expert.Name;
            existingExpert.Email = expert.Email;
            existingExpert.Password = expert.Password;

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

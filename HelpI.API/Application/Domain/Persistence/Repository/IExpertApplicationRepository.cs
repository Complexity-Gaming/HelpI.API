using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Application.Domain.Models;

namespace HelpI.API.Application.Domain.Persistence.Repository
{
    public interface IExpertApplicationRepository
    {
        Task<IEnumerable<ExpertApplication>> ListAsync();
        Task<ExpertApplication> FindById(int id);
        Task<IEnumerable<ExpertApplication>> ListByApplicantIdAsync(int applicantId);
        Task AddAsync(ExpertApplication application);
        void Update(ExpertApplication application);
        void Remove(ExpertApplication expertApplication);
    }
}

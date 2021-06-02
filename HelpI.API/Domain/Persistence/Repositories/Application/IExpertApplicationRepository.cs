using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Application;

namespace HelpI.API.Domain.Persistence.Repositories.Application
{
    public interface IExpertApplicationRepository
    {
        Task<IEnumerable<ExpertApplication>> ListAsync();
        Task<ExpertApplication> FindById(int id);
        Task<IEnumerable<ExpertApplication>> ListByApplicantIdAsync(int applicantId);
        void Update(ExpertApplication application);
        void Remove(ExpertApplication expertApplication);
    }
}

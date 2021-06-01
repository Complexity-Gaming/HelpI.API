using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Security;

namespace HelpI.API.Domain.Services.Application
{
    public interface IExpertApplicationService
    {
        Task<IEnumerable<ExpertApplication>> ListAsync();
        Task<ExpertApplicationResponse> GetByIdAsync(int id);
        Task<IEnumerable<ExpertApplication>> ListByApplicantIdAsync(int applicantId);
        Task<ExpertApplicationResponse> SendExpertApplication(int applicantId, ExpertApplication expertApplication);
        Task<ExpertResponse> ReviewApplicationAsync(int id, string review, string reviewComment);
        Task<ExpertApplicationResponse> DeleteAsync(int id);
    }
}

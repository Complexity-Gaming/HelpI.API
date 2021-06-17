using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Application.Domain.Models;
using HelpI.API.Application.Domain.Services.Communications;
using HelpI.API.Security.Domain.Services.Communication;

namespace HelpI.API.Application.Domain.Services
{
    public interface IExpertApplicationService
    {
        Task<IEnumerable<ExpertApplication>> ListAsync();
        Task<ExpertApplicationResponse> GetByIdAsync(int id);
        Task<IEnumerable<ExpertApplication>> ListByApplicantIdAsync(int playerId);
        Task<ExpertApplicationResponse> SendExpertApplication(int playerId, ExpertApplication expertApplication);
        Task<ExpertResponse> ReviewApplicationAsync(int id, string review, string reviewComment);
        Task<ExpertApplicationResponse> DeleteAsync(int id);
    }
}

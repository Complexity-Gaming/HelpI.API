using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Services.Communication;

namespace HelpI.API.Security.Domain.Services
{
    public interface IExpertService
    {
        Task<IEnumerable<Expert>> ListAsync();
        Task<ExpertResponse> GetByIdAsync(int id);
        Task<ExpertResponse> SaveAsync(Expert expert);
        Task<ExpertResponse> UpdateAsync(int id, Expert expert);
        Task<ExpertResponse> DeleteAsync(int id);
        Task<IEnumerable<Expert>> ListByGameIdAsync(int gameId);
        Task<ExpertResponse> UpdateProfileAsync(int id, ExpertProfile profile);
    }
}

using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services
{
    public interface IExpertService
    {
        Task<IEnumerable<Expert>> ListAsync();
        Task<ExpertResponse> GetByIdAsync(int id);
        Task<ExpertResponse> SaveAsync(Expert expert);
        Task<ExpertResponse> UpdateAsync(int id, Expert expert);
        Task<ExpertResponse> DeleteAsync(int id);
    }
}

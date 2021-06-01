using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Services.Communications;

namespace HelpI.API.Domain.Services.Session
{
    public interface IScheduledSessionService
    {
        Task<IEnumerable<ScheduledSession>> ListAsync();
        Task<ScheduledSessionResponse> GetByIdAsync(int id);
        Task<ScheduledSessionResponse> DeleteAsync(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Security.Domain.Models;

namespace HelpI.API.Security.Domain.Persistence.Repositories
{
    public interface IExpertRepository
    {
        Task<IEnumerable<Expert>> ListAsync();
        Task AddAsync(Expert expert);
        Task<Expert> FindById(int id);
        void Update(Expert expert);
        void Remove(Expert expert);
        Task<int> GetNewIdAsync();
        Task<IEnumerable<Expert>> FindByGameIdAsync(int gameId);
    }
}

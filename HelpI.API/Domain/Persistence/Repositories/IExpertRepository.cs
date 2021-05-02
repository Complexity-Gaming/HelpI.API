using HelpI.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Persistence.Repositories
{
    public interface IExpertRepository
    {
        Task<IEnumerable<Expert>> ListAsync();
        Task AddAsync(Expert expert);
        Task<Expert> FindById(int id);
        void Update(Expert expert);
        void Remove(Expert expert);
    }
}

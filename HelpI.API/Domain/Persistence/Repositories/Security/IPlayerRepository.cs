using HelpI.API.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Persistence.Repositories.Security
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> ListAsync();
        Task AddAsync(Player player);
        Task<Player> FindById(int id);
        void Update(Player player);
        void Remove(Player player);
    }
}

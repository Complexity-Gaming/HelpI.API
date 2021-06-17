using System.Collections.Generic;
using System.Threading.Tasks;
using IGDB.Models;

namespace HelpI.API.Games.Domain.Persistence
{
    public interface IGamesApiFacade
    {
        Task<IEnumerable<Game>> ListAsync();
        Task<Game> FindById(long? id);
    }
}
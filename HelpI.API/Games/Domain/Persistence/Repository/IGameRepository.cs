using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Games.Domain.Models;

namespace HelpI.API.Games.Domain.Persistence.Repository
{
    public interface IGameRepository
    {
        Task<IEnumerable<GameModel>> ListAsync();
        Task<GameModel> FindById(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Games.Domain.Models;
using HelpI.API.Games.Domain.Services.Communications;

namespace HelpI.API.Games.Domain.Services
{
    public interface IGameService
    {
        Task<GameResponse> GetGameByIdAsync(int gameId);
        Task<IEnumerable<GameModel>> GetAllAsync();
    }
}
using System.Threading.Tasks;
using HelpI.API.Games.Domain.Services.Communications;
using IGDB.Models;

namespace HelpI.API.Games.Domain.Services
{
    public interface IGameService
    {
        Task<GameResponse> GetGameByIdAsync(int gameId);
    }
}
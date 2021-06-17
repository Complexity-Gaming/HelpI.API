using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Games.Domain.Models;
using HelpI.API.Games.Domain.Persistence;
using HelpI.API.Games.Domain.Persistence.Repository;
using HelpI.API.Games.Domain.Services;
using HelpI.API.Games.Domain.Services.Communications;
using IGDB.Models;

namespace HelpI.API.Games.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGamesApiFacade _gamesApiFacade;
        private readonly IGameRepository _gameRepository;

        public GameService(IGamesApiFacade gamesApiFacade, IGameRepository gameRepository)
        {
            _gamesApiFacade = gamesApiFacade;
            _gameRepository = gameRepository;
        }

        public async Task<GameResponse> GetGameByIdAsync(int gameId)
        {
            var gameModel = await _gameRepository.FindById(gameId);
            
            if (gameModel == null) 
                return new GameResponse($"Game not found with gameId: {gameId}");
            
            var gameProvided = await _gamesApiFacade.FindById(gameModel.ProviderId);
            
            gameModel.SetProviderData(gameProvided);
            
            return new GameResponse(gameModel);
        }
        public async Task<IEnumerable<GameModel>> GetAllAsync()
        {
            var enumerableGameModels = await _gameRepository.ListAsync();
            var enumerableProvidedGames = await _gamesApiFacade.ListAsync();
            
            var gameModels = enumerableGameModels.ToList();
            var providedGames = enumerableProvidedGames.ToList();
            
            foreach (var game in gameModels)
            {
                game.SetProviderData(providedGames.First(g => g.Id == game.ProviderId));
            }
            return gameModels;
        }
    }
}
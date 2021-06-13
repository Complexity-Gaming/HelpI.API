using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HelpI.API.Games.Domain.Models;
using HelpI.API.Games.Domain.Services;
using HelpI.API.Games.Domain.Services.Communications;
using IGDB;
using IGDB.Models;
using Microsoft.Win32.SafeHandles;

namespace HelpI.API.Games.Application 
{
    public class GamesApiFacade : IGameService
    {
        private const string IgdbClientId = "ov3od6hqyjyb0iurx0hbbvp6ijde7v";
        private const string IgdbClientSecret = "7jtzb99a7qf3yplg6m0jvst5d5wbp1";

        public async Task<GameResponse> GetGameByIdAsync(int gameId)
        {
            IGDBClient client = new IGDBClient(IgdbClientId, IgdbClientSecret);
            var game = await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields *, cover.*; where id = {gameId};");
            if (game == null) 
                return new GameResponse($"Game not found with gameId: {gameId}");
            
            var cover = game.First().Cover.Value;
            cover.Url = IGDB.ImageHelper.GetImageUrl(cover.ImageId, size: ImageSize.HD1080);
            
            var gameModel = new GameModel(game.First().Id, game.First().Name, game.First().Storyline, game.First().Summary, cover.Url, cover.Height, cover.Width);
            
            return new GameResponse(gameModel);
        }

        public async Task<IEnumerable<GameModel>> GetAllAsync()
        {
            IGDBClient client = new IGDBClient(IgdbClientId, IgdbClientSecret);
            var games = await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields *, cover.*; where id = (2963,114795,131800,1372);");
            List<GameModel> gameModels = new List<GameModel>();
            foreach (var game in games)
            {
                var cover = game.Cover.Value;
                cover.Url = IGDB.ImageHelper.GetImageUrl(cover.ImageId, size: ImageSize.HD1080);
                gameModels.Add(new GameModel(game.Id, game.Name, game.Storyline, game.Summary, cover.Url, cover.Height, cover.Width));
            }
            return gameModels;
        }
    }
}
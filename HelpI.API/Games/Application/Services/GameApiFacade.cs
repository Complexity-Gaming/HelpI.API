using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Games.Domain.Models;
using HelpI.API.Games.Domain.Persistence;
using HelpI.API.Games.Domain.Services.Communications;
using IGDB;
using IGDB.Models;

namespace HelpI.API.Games.Application.Services 
{
    public class GamesApiFacade : IGamesApiFacade
    {
        private const string IgdbClientId = "ov3od6hqyjyb0iurx0hbbvp6ijde7v";
        private const string IgdbClientSecret = "7jtzb99a7qf3yplg6m0jvst5d5wbp1";
        private readonly IGDBClient _client;
        public GamesApiFacade()
        {
            _client = new IGDBClient(IgdbClientId, IgdbClientSecret);
        }

        public async Task<IEnumerable<Game>> ListAsync()
        {
            var games = await _client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields *, cover.*; where id = (2963,114795,131800,1372);");
            foreach (var game in games)
            {
                game.Cover.Value.Url = IGDB.ImageHelper.GetImageUrl( game.Cover.Value.ImageId, size: ImageSize.HD1080);
            }
            return games;
        }

        public async Task<Game> FindById(long? id)
        {
            var game = await _client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields *, cover.*; where id = {id};");
            game.First().Cover.Value.Url =
                IGDB.ImageHelper.GetImageUrl(game.First().Cover.Value.ImageId, size: ImageSize.HD1080);
            return game.First();
        }
    }
}
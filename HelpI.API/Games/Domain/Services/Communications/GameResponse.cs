using HelpI.API.Games.Domain.Models;
using HelpI.API.SeedWork.Communications;

namespace HelpI.API.Games.Domain.Services.Communications
{
    public class GameResponse : BaseResponse<GameModel>
    {
        public GameResponse(GameModel resource) : base(resource)
        {
        }

        public GameResponse(string message) : base(message)
        {
        }
    }
}
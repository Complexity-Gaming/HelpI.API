using HelpI.API.Domain.Services.Communications;
using HelpI.API.Games.Domain.Models;

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
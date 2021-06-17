using HelpI.API.Security.Domain.Models;
using HelpI.API.SeedWork.Communications;

namespace HelpI.API.Security.Domain.Services.Communication
{
    public class PlayerResponse : BaseResponse<Player>
    {
        public PlayerResponse(Player resource) : base(resource)
        {
        }

        public PlayerResponse(string message) : base(message)
        {
        }
    }
}

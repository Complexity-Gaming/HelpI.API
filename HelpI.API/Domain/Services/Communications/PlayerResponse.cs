using HelpI.API.Domain.Models;
using HelpI.API.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Communications
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

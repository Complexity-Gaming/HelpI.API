using HelpI.API.Games.Domain.Models;
using HelpI.API.Security.Domain.Models;

namespace HelpI.API.Security.Application.Transform.Resources
{
    public class ExpertResource : PlayerResource
    {
        public int GameId { get; set; }
        public ExpertProfile ExpertProfile { get; set; }
    }
}

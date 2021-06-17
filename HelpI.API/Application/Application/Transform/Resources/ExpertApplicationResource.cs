using System;
using HelpI.API.Security.Application.Transform.Resources;

namespace HelpI.API.Application.Application.Transform.Resources
{
    public class ExpertApplicationResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        public int GameId { get; set; }
        public Uri VideoApplication { get; set; }
        public string Status { get; set; }
        
        public PlayerResource Player { get; set; }
    }
}

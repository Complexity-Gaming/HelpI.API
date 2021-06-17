using System;

namespace HelpI.API.Application.Application.Transform.Resources
{
    public class SaveExpertApplicationResource
    {
        public int Id { get; set;}
        public int GameId { get; set; }
        public string Description { get; set; }
        public Uri VideoApplication { get; set; }
    }
}

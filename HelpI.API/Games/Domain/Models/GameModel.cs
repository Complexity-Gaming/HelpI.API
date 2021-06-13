using System;
using Org.BouncyCastle.Crypto.Engines;

namespace HelpI.API.Games.Domain.Models
{
    public class GameModel
    {
        public GameModel(long? id, string name, string storyLine, string summary, string coverUrl, int? coverHeight, int? coverWidth)
        {
            Id = id;
            Name = name;
            StoryLine = storyLine;
            Summary = summary;
            CoverUrl = coverUrl;
            CoverHeight = coverHeight;
            CoverWidth = coverWidth;
        }

        public long? Id { get; set; }
        public string Name { get; set; }
        public string StoryLine { get; set; }
        public string Summary { get; set; }
        public string CoverUrl { get; set; }
        public int? CoverHeight { get; set; }
        public int? CoverWidth { get; set; }
    }
}
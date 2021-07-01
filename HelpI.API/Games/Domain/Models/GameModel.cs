using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using HelpI.API.Security.Domain.Models;
using IGDB;
using IGDB.Models;
using Org.BouncyCastle.Crypto.Engines;

namespace HelpI.API.Games.Domain.Models
{
    public class GameModel
    { 
        public int Id { get; set; }
        public long? ProviderId { get; set; }
        public string Name { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string ProviderName { get; set; }
        public string StoryLine { get; set; }
        public string Summary { get; set; }
        public string CoverUrl { get; set; }
        public int? CoverHeight { get; set; }
        public int? CoverWidth { get; set; }
        [JsonIgnore]
        public List<Expert> Experts { get; set; }

        public GameModel()
        {
            
        }
        public GameModel(int id, long? providerId, string name)
        {
            Id = id;
            ProviderId = providerId;
            Name = name;
        }
        public void SetProviderData(Game providerModel)
        {
            this.ProviderName = providerModel.Name;
            this.StoryLine = providerModel.Storyline;
            this.Summary = providerModel.Summary;
            this.CoverUrl = providerModel.Cover.Value.Url;
            this.CoverHeight = providerModel.Cover.Value.Height;
            this.CoverWidth = providerModel.Cover.Value.Width;
            this.BackgroundImageUrl = getRandomBackgroundImageUrl(providerModel.Screenshots.Values.ToList());
        }
        private string getRandomBackgroundImageUrl(List<Screenshot> screenshots)
        {
            var random = new Random();
            var position = screenshots.Count;
            int ran = random.Next(position);
            return IGDB.ImageHelper.GetImageUrl(screenshots[ran].ImageId, size: ImageSize.ScreenshotBig);

        }
    }
}
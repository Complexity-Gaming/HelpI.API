using System;
using System.Collections.Generic;
using HelpI.API.Security.Domain.Models;
using IGDB.Models;
using Org.BouncyCastle.Crypto.Engines;

namespace HelpI.API.Games.Domain.Models
{
    public class GameModel
    { 
        public int Id { get; set; }
        public long? ProviderId { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string StoryLine { get; set; }
        public string Summary { get; set; }
        public string CoverUrl { get; set; }
        public int? CoverHeight { get; set; }
        public int? CoverWidth { get; set; }
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
        }
       
    }
}
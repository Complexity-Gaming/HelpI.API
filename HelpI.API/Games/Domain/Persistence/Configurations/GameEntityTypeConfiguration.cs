using HelpI.API.Games.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpI.API.Games.Domain.Persistence.Configurations
{
    public class GameEntityTypeConfiguration : IEntityTypeConfiguration<GameModel>

    {
        public void Configure(EntityTypeBuilder<GameModel> gameConfiguration)
        {
            gameConfiguration.ToTable("Games");
            gameConfiguration.HasKey(p => p.Id);
            gameConfiguration.Property(p => p.Id).IsRequired();
            gameConfiguration.Property(p => p.ProviderId);
            gameConfiguration.Property(p => p.Name);
            gameConfiguration.Ignore(p => p.ProviderName);
            gameConfiguration.Ignore(p => p.StoryLine);
            gameConfiguration.Ignore(p => p.Summary);
            gameConfiguration.Ignore(p => p.CoverUrl);
            gameConfiguration.Ignore(p => p.CoverHeight);
            gameConfiguration.Ignore(p => p.CoverWidth);
            gameConfiguration.Ignore(p => p.BackgroundImageUrl);
            CreateData(gameConfiguration);
        }

        private void CreateData(EntityTypeBuilder<GameModel> gameConfiguration)
        {
            gameConfiguration.HasData(
                new GameModel(id:1, providerId:1372, name:"Counter-Strike: Global Offensive"),
                new GameModel(id:2, providerId:2963, name:"Dota 2"),
                new GameModel(id:3, providerId:114795, name:"Apex Legends"),
                new GameModel(id:4, providerId:131800, name:"Call of Duty: Warzone")
            );
        }
    }
}
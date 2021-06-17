using HelpI.API.Security.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpI.API.Security.Domain.Persistence.Configuration
{
    public class ExpertEntityTypeConfiguration : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> expertConfiguration)
        {
            expertConfiguration.OwnsOne(
                o => o.ExpertProfile,
                sa =>
                {
                    sa.Property(p => p.Elo).HasColumnName("Elo");
                    sa.Property(p => p.ExperienceStory).HasColumnName("ExperienceStory");
                    sa.Property(p => p.StartedPlaying).HasColumnName("StartedPlaying");
                    sa.Property(p => p.WhyMe).HasColumnName("WhyMe");
                    sa.Property(p => p.GameUserName).HasColumnName("GameUserName");
                });
            // Relationships
            expertConfiguration
                .HasMany(p => p.TrainingMaterials)
                .WithOne(p => p.CreatedBy)
                .HasForeignKey(p => p.ExpertId);

            expertConfiguration
                .HasOne(p => p.Game)
                .WithMany(g => g.Experts)
                .HasForeignKey(p => p.GameId);
        }
    }
}
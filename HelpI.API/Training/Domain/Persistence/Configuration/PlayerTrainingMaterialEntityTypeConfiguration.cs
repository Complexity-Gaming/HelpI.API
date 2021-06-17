using HelpI.API.Training.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpI.API.Training.Domain.Persistence.Configuration
{
    public class PlayerTrainingMaterialEntityTypeConfiguration : IEntityTypeConfiguration<PlayerTrainingMaterial>
    {
        public void Configure(EntityTypeBuilder<PlayerTrainingMaterial> playerTrainingConfiguration)
        {
            playerTrainingConfiguration.ToTable("PlayerTrainings");
            // Constraints
            playerTrainingConfiguration.HasKey(p => new { p.PlayerId, p.TrainingMaterialId});

            // Relationships
            playerTrainingConfiguration
                .HasOne(pt => pt.Player)// PlayerTrainingMaterial Has one Player
                .WithMany(t => t.PlayerTrainingMaterials) // Player Has many PlayerTrainingMaterial
                .HasForeignKey(pt => pt.PlayerId); // PlayerTrainingMaterial Has ForeignKey from Player

            playerTrainingConfiguration
                .HasOne(pt => pt.TrainingMaterial) // PlayerTrainingMaterial Has one Training Material
                .WithMany(t => t.PlayerTrainingMaterials) // TraningMaterial Has many PlayerTrainingMaterial
                .HasForeignKey(pt => pt.TrainingMaterialId); // PlayerTrainingMaterial Has ForeignKey from TrainingMaterial

        }
    }
}
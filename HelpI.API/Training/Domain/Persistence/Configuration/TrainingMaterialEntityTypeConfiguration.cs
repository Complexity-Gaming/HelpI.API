using HelpI.API.Training.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpI.API.Training.Domain.Persistence.Configuration
{
    public class TrainingMaterialEntityTypeConfiguration : IEntityTypeConfiguration<TrainingMaterial>
    {
        public void Configure(EntityTypeBuilder<TrainingMaterial> trainingConfiguration)
        {
            // Training Material Entity
            trainingConfiguration.ToTable("TrainingMaterials");
            // Constraints
            trainingConfiguration.HasKey(p => p.Id);
            trainingConfiguration.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            trainingConfiguration.Property(p => p.GameId).IsRequired();
            trainingConfiguration.Property(p => p.Description);
            trainingConfiguration.OwnsOne(m => m.TrainingDetails, a => {
                a.Property(p => p.VideoUri).HasColumnName("VideoUrl");
                a.Property(p => p.PublishedDate).HasColumnName("PublishedDate");
                a.Property(p => p.Currency).HasColumnName("Currency");
                a.Property(p => p.Price).HasColumnName("Price");
            });
            trainingConfiguration.OwnsOne(m => m.TrainingMaterialId, a => {
                a.Property(p => p.TrainingMaterialId).HasColumnName("TrainingId") ;
            });
        }
    }
}
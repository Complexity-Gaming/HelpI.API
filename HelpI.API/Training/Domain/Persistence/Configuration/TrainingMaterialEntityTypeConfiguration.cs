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
            trainingConfiguration.OwnsOne(m => m.TrainingDetails, a => {
                a.ToTable("TrainingDetails");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.VideoUri);
                a.Property(p => p.PublishedDate);
                a.Property(p => p.Currency);
            });
            trainingConfiguration.OwnsOne(m => m.TrainingMaterialId, a => {
                a.ToTable("TrainingIds");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.TrainingMaterialId).HasColumnName("TrainingId") ;
            });
        }
    }
}
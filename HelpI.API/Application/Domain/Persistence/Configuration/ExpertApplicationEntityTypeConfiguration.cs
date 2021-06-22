using HelpI.API.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpI.API.Application.Domain.Persistence.Configuration
{
    public class ExpertApplicationEntityTypeConfiguration : IEntityTypeConfiguration<ExpertApplication>
    {
        public void Configure(EntityTypeBuilder<ExpertApplication> expertApplicationConfiguration)
        {
            expertApplicationConfiguration.ToTable("ExpertApplications");
            expertApplicationConfiguration.HasKey(p => p.Id);
            expertApplicationConfiguration.Property(p => p.Id).IsRequired();
            expertApplicationConfiguration.OwnsOne(m => m.ApplicationForm, a => {
                a.Property(p => p.Description).HasColumnName("Description");
                a.Property(p => p.VideoApplication).HasColumnName("VideoApplication");
                a.Property(p => p.ReviewComment).HasColumnName("ReviewComment");
                a.Property(p => p.Status).HasColumnName("Status");
            });
            expertApplicationConfiguration.HasOne(p => p.Player).WithMany(p => p.ExpertApplications)
                .HasForeignKey(p => p.PlayerId);

            expertApplicationConfiguration.Property(p => p.GameId);
        }
    }
}
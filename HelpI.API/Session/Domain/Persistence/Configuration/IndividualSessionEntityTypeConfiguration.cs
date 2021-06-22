using HelpI.API.Session.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpI.API.Session.Domain.Persistence.Configuration
{
    public class IndividualSessionEntityTypeConfiguration : IEntityTypeConfiguration<IndividualSession>
    {
        public void Configure(EntityTypeBuilder<IndividualSession> individualSessionConfiguration)
        {
            // Individual Session Entity
            individualSessionConfiguration.ToTable("IndividualSessions");

            // Constraints
            individualSessionConfiguration.HasKey(p => p.Id);
            individualSessionConfiguration.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            
            individualSessionConfiguration.OwnsOne(m => m.SessionReview, a =>  {
                a.Property(p => p.Comment).HasColumnName("Comment");
                a.Property(p => p.Review).HasColumnName("Review");
            });
            individualSessionConfiguration.OwnsOne(m => m.SessionId, a => {
                a.Property(p => p.IndividualSessionId).HasColumnName("SessionId");
            });
            individualSessionConfiguration.OwnsOne(m => m.Price, a => {
                a.Property(p => p.Amount).HasColumnName("Amount");
                a.Property(p => p.Currency).HasColumnName("Currency");
            });
            
            individualSessionConfiguration.OwnsOne(m => m.SessionDate, a => {
                a.Property(p => p.Date).HasColumnName("Date");
                a.Property(p => p.Duration).HasColumnName("Duration");
            });
            individualSessionConfiguration
                .HasOne(p => p.Player)
                .WithMany(p => p.AssistedSessions)
                .HasForeignKey(p => p.PlayerId);
            
            individualSessionConfiguration
                .HasOne(p => p.Expert)
                .WithMany(p => p.GivenSessions)
                .HasForeignKey(p => p.ExpertId);
        }
    }
}
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
            individualSessionConfiguration.Ignore(p => p.SessionDate);
            individualSessionConfiguration.Ignore(p => p.Price);
            individualSessionConfiguration.OwnsOne(m => m.SessionCalification, a =>  {
                a.ToTable("Califications");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.Comment);
                a.Property(p => p.Calification);
            });
            individualSessionConfiguration.OwnsOne(m => m.IndividualSessionId, a => {
                a.ToTable("IndSessionsIds");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.IndividualSessionId).HasColumnName("IndSessionId");
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
using HelpI.API.Security.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EntityFrameworkCore.Extensions;

namespace HelpI.API.Security.Domain.Persistence.Configuration
{
    public class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> playerConfiguration)
        {
            playerConfiguration.ToTable("Players")
                .HasDiscriminator<string>("PlayerType")
                .HasValue<Player>("player")
                .HasValue<Expert>("expert"); 
            // Constraints
            playerConfiguration.HasKey(p => p.Id);
            playerConfiguration.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            playerConfiguration.Property(p => p.Email).IsRequired().HasMaxLength(35);
            playerConfiguration.Property(p => p.Password).IsRequired().HasMaxLength(15);
            
            playerConfiguration.OwnsOne(
                o => o.PersonalProfile,
                sa =>
                {
                    sa.Property(p => p.FirstName).HasColumnName("FirstName");
                    sa.Property(p => p.LastName).HasColumnName("LastName");
                    sa.Property(p => p.Birthdate).HasColumnName("Birthdate");
                });
            
            // Relationships
            playerConfiguration
                .HasMany(p => p.ExpertApplications)
                .WithOne(p => p.Player)
                .HasForeignKey(p => p.PlayerId);
        }
    }
}
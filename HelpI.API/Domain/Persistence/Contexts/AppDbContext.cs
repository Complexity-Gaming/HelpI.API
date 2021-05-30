using HelpI.API.Application.Extensions;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Training;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<TrainingMaterial> TrainingMaterials { get; set; }
        public DbSet<PlayerTrainingMaterial> PlayerTrainingMaterials { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            //// Player Entity
            builder.Entity<Player>().ToTable("Players");
            // Constraints
            builder.Entity<Player>().HasKey(p => p.Id);
            builder.Entity<Player>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Player>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Player>().Property(p => p.LastName).IsRequired();
            builder.Entity<Player>().Property(p => p.Email).IsRequired().HasMaxLength(15);
            builder.Entity<Player>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            builder.Entity<Player>().Property(p => p.Birthdate).IsRequired();

            // Expert Entity
            builder.Entity<Expert>().ToTable("Experts");

            // Constraints
            builder.Entity<Expert>().HasKey(p => p.Id);
            builder.Entity<Expert>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Expert>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Expert>().Property(p => p.LastName).IsRequired();
            builder.Entity<Expert>().Property(p => p.Email).IsRequired().HasMaxLength(15);
            builder.Entity<Expert>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            builder.Entity<Expert>().Property(p => p.Birthdate).IsRequired();

            // Relationships
            builder.Entity<Expert>()
               .HasMany(p => p.TrainingMaterials)
               .WithOne(p => p.CreatedBy)
                .HasForeignKey(p => p.ExpertId);


            // Training Material Entity
            builder.Entity<TrainingMaterial>().ToTable("TrainingMaterials");
            
            // Constraints
            builder.Entity<TrainingMaterial>().HasKey(p => p.Id);
            builder.Entity<TrainingMaterial>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TrainingMaterial>().Property(p => p.Price).IsRequired();

            // PlayerTraininmaterial Entity
            builder.Entity<PlayerTrainingMaterial>().ToTable("PlayerTrainings");

            // Constraints
            builder.Entity<PlayerTrainingMaterial>().HasKey(p => new { p.PlayerId, p.TrainingMaterialId});

            // Relationships

            builder.Entity<PlayerTrainingMaterial>()
                .HasOne(pt => pt.Player)// PlayerTrainingMaterial Has one Player
                .WithMany(t => t.PlayerTrainingMaterials) // Player Has many PlayerTrainingMaterial
                .HasForeignKey(pt => pt.PlayerId); // PlayerTrainingMaterial Has ForeignKey from Player

            builder.Entity<PlayerTrainingMaterial>()
                .HasOne(pt => pt.TrainingMaterial) // PlayerTrainingMaterial Has one Training Material
                .WithMany(t => t.PlayerTrainingMaterials) // TraningMaterial Has many PlayerTrainingMaterial
                .HasForeignKey(pt => pt.TrainingMaterialId); // PlayerTrainingMaterial Has ForeignKey from TrainingMaterial

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}

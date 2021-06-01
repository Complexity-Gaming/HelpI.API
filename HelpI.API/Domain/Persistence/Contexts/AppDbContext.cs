using HelpI.API.Application.Extensions;
using HelpI.API.Domain.Models.Security;
using HelpI.API.Domain.Models.Session;
using HelpI.API.Domain.Models.Training;
using HelpI.API.Domain.Models.Application;
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
        public DbSet<IndividualSession> IndividualSessions { get; set; }
        public DbSet<CoachApplication> CoachApplications { get; set; }
        public DbSet<ScheduledSession> ScheduledSessions { get; set; }

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
            builder.Entity<TrainingMaterial>().OwnsOne(m => m.TrainingDetails, a => {
                a.ToTable("TrainingDetails");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.VideoUri);
                a.Property(p => p.PublishedDate);
                a.Property(p => p.Currency);
            });
            builder.Entity<TrainingMaterial>().OwnsOne(m => m.TrainingMaterialId, a => {
                a.ToTable("TrainingIds");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.TrainingMaterialId).HasColumnName("TrainingId") ;
            });

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

            //CoachApplication entity
            builder.Entity<CoachApplication>().ToTable("CoachApplications");

            //Constraints
            builder.Entity<CoachApplication>().HasKey(p => p.Id);
            builder.Entity<CoachApplication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CoachApplication>().OwnsOne(m => m.ApplicationDetails, a => {
                a.ToTable("AplicationDetails");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.Description);
                a.Property(p => p.VideoApplication);
                a.Property(p => p.Passed);
            });
            builder.Entity<CoachApplication>().OwnsOne(m => m.CoachAplicationId, a => {
                a.ToTable("AplicationsIds");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.CoachApplicationId).HasColumnName("AplicationId");
            });

            // Individual Sesion Entity
            builder.Entity<IndividualSession>().ToTable("IndividualSessions");

            // Constraints
            builder.Entity<IndividualSession>().HasKey(p => p.Id);
            builder.Entity<IndividualSession>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<IndividualSession>().OwnsOne(m => m.SessionCalification, a =>  {
                a.ToTable("Califications");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.Comment);
                a.Property(p => p.Calification);
            });
            builder.Entity<IndividualSession>().OwnsOne(m => m.IndividualSessionId, a => {
                a.ToTable("IndSessionsIds");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.IndividualSessionId).HasColumnName("IndSessionId");
            });
            
            // Scheduled Sesion Entity
            builder.Entity<ScheduledSession>().ToTable("ScheduledSessions");

            // Constraints
            builder.Entity<ScheduledSession>().HasKey(p => p.Id);
            builder.Entity<ScheduledSession>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ScheduledSession>().OwnsOne(m => m.Price, a => {
                a.ToTable("Moneys");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.Ammount);
                a.Property(p => p.Currency);
            });
            builder.Entity<ScheduledSession>().OwnsOne(m => m.ScheduledSessionId, a => {
                a.ToTable("ScheSessionsIds");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.ScheduledSessionId).HasColumnName("ScheSessionId");
            });
            builder.Entity<ScheduledSession>().OwnsOne(m => m.SessionDate, a =>{
                a.ToTable("SessionDate");
                a.Property<int>("Id").IsRequired().ValueGeneratedOnAdd();
                a.HasKey("Id");
                a.Property(p => p.Date);
                a.Property(p => p.Duration);
            });

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}

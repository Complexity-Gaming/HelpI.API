using HelpI.API.Application.Domain.Models;
using HelpI.API.Application.Domain.Persistence.Configuration;
using HelpI.API.Games.Domain.Models;
using HelpI.API.Games.Domain.Persistence.Configurations;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Persistence.Configuration;
using HelpI.API.SeedWork.Extensions;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Session.Domain.Persistence.Configuration;
using HelpI.API.Training.Domain.Models;
using HelpI.API.Training.Domain.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.SeedWork.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<TrainingMaterial> TrainingMaterials { get; set; }
        public DbSet<PlayerTrainingMaterial> PlayerTrainingMaterials { get; set; }
        public DbSet<ExpertApplication> ExpertApplications { get; set; }
        public DbSet<IndividualSession> IndividualSessions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlayerEntityTypeConfiguration());
            builder.ApplyConfiguration(new ExpertEntityTypeConfiguration());
            builder.ApplyConfiguration(new TrainingMaterialEntityTypeConfiguration());
            builder.ApplyConfiguration(new PlayerTrainingMaterialEntityTypeConfiguration());
            builder.ApplyConfiguration(new ExpertApplicationEntityTypeConfiguration());
            builder.ApplyConfiguration(new IndividualSessionEntityTypeConfiguration());
            builder.ApplyConfiguration(new GameEntityTypeConfiguration());
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}

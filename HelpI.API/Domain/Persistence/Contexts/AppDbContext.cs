using HelpI.API.Domain.Models;
using HelpI.API.Extensions;
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

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Player Entity
            builder.Entity<Player>().ToTable("Players");

            // Constraints
            builder.Entity<Player>().HasKey(p => p.Id);
            builder.Entity<Player>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Player>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Player>().Property(p => p.Email).IsRequired();
            builder.Entity<Player>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            //builder.Entity<Player>().Property(p => p.BirthDate).IsRequired();

            // Expert Entity
            builder.Entity<Expert>().ToTable("Experts");

            // Constraints
            builder.Entity<Expert>().HasKey(p => p.Id);
            builder.Entity<Expert>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Expert>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Expert>().Property(p => p.Email).IsRequired();
            builder.Entity<Expert>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            //builder.Entity<Expert>().Property(p => p.BirthDate).IsRequired();

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}

using CrowdFundingProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Backer> Backers { get; set; }
        public DbSet<Image> Images { get; set; }


        private readonly string connectionString =
            "Server = tcp:team4.database.windows.net,1433;Initial Catalog = Project; Persist Security Info=False;User ID = team4;" +
            "Password=Project4; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 50,
                        maxRetryDelay: TimeSpan.FromSeconds(2),
                        errorNumbersToAdd: null);
                });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creator>();
            modelBuilder.Entity<Creator>()
                .Property(c=> c.Username)
                .IsRequired();
            modelBuilder.Entity<Creator>()
                .Property(c => c.Email)
                .IsRequired();

            modelBuilder.Entity<Backer>();
            modelBuilder.Entity<Backer>().HasMany(c => c.SupportingProjects);
            modelBuilder.Entity<Backer>().HasMany(c => c.Tags);
            modelBuilder.Entity<Backer>()
                .Property(c => c.Username)
                .IsRequired();
            modelBuilder.Entity<Backer>()
                .Property(c => c.Email)
                .IsRequired();

            modelBuilder.Entity<Bundle>();
            modelBuilder.Entity<Bundle>()
                .Property(c => c.Prize)
                .IsRequired();

            modelBuilder.Entity<Project>();
            modelBuilder.Entity<Project>().HasOne(c => c.Creator);
            modelBuilder.Entity<Project>().HasMany(c => c.Backers);
            modelBuilder.Entity<Project>().HasMany(c => c.Bundles);
            modelBuilder.Entity<Tag>();
            modelBuilder.Entity<Image>();
        }
    }
}

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
        public DbSet<Tag> Tags { get; set; }        
        public DbSet<Image> Images { get; set; }        
        public DbSet<BackerBundle> BackerBundles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
            {
            }            
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creator>();
            modelBuilder.Entity<Creator>()
                .Property(c => c.Username)
                .IsRequired();
            modelBuilder.Entity<Creator>()
                .Property(c => c.Email)
                .IsRequired();

            modelBuilder.Entity<Backer>();            
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
            modelBuilder.Entity<Project>().HasMany(c => c.Bundles);
            modelBuilder.Entity<Tag>().HasData(
                new Tag{Id = 1,Name = "Technology"},
                new Tag{Id = 2,Name = "Fashion"},
                new Tag{Id = 3,Name = "Travel"},
                new Tag{Id = 4,Name = "Music"},
                new Tag{Id = 5,Name = "Arts"},
                new Tag{Id = 6,Name = "Sports"},
                new Tag{Id = 7,Name = "Food"},
                new Tag{Id = 8,Name = "Games"},
                new Tag{Id = 9,Name = "Movies"}                
                );
            modelBuilder.Entity<Image>();

            modelBuilder.Entity<BackerBundle>().HasKey(key => key.Id);
        }
    }
}

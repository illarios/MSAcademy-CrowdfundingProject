using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace CrowdFundingProject.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly AppDbContext dbContext;
        public CreatorService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public CreatorOptions CreateCreator(CreatorOptions creatorOptions)
        {          
            Creator creator = new Creator 
            {
                Username = creatorOptions.Username,
                Email = creatorOptions.Email,
                Bio = creatorOptions.Bio,
                IsActive = true
            };
            
            dbContext.Creators.Add(creator);
            dbContext.SaveChanges();


            return new CreatorOptions {
                Username = creator.Username,
                Email = creator.Email,
                Bio = creator.Bio
            };
        }

        public bool DeleteCreator(int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);
            if (creator == null) return false;
            creator.IsActive = false;
            dbContext.SaveChanges();
            return true;
        }
        public int CheckIfEmailExists(string email)
        {
            Creator cr = new Creator();
            cr = dbContext.Creators.FirstOrDefault(i => i.Email == email);
            if (cr == null) return -1;
            return cr.Id;
        }

        public List<Creator> GetCreators()
        {
            List<Creator> creators = dbContext.Creators.ToList();
            return creators;
        }

        public CreatorOptions GetCreatorById(int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);
            return new CreatorOptions 
            {
                Id = creator.Id,
                Username = creator.Username,
                Email = creator.Email,
                Bio = creator.Bio,
                IsActive = creator.IsActive
            };
        }

        public CreatorOptions UpdateCreator(CreatorOptions creatorOptions, int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);

            creator.Bio = creatorOptions.Bio;
            creator.Email = creatorOptions.Email;
            dbContext.SaveChanges();

            return new CreatorOptions
            {
                Username = creator.Username,
                Bio = creator.Bio,
                Email = creator.Email
            };
        }

        public List<Project> GetAllProjects(int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);
            List<Project> projects = creator.Projects.ToList();
            return projects;
        }

        public Creator GetCreatorByUsername(string username)
        {
            Creator creator = dbContext.Creators.ToList().Find(c => c.Username == username);
            return creator;
        }
    }
}

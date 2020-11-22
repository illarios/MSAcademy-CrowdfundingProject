using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdFundingProject.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly AppDbContext dbContext = new AppDbContext();
        public Creator CreateCreator(CreatorOptions creatorOptions)
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
            return creator;
        }

        public bool DeleteCreator(int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);
            if (creator == null) return false;
            creator.IsActive = false;
            dbContext.SaveChanges();
            return true;
        }

        public List<Creator> GetCreators()
        {
            List<Creator> creators = dbContext.Creators.ToList();
            return creators;
        }

        public Creator GetCreatorById(int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);
            return creator;
        }

        public Creator UpdateCreator(CreatorOptions creatorOptions, int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);

            creator.Bio = creatorOptions.Bio;
            creator.Email = creatorOptions.Email;
            dbContext.SaveChanges();

            return creator;
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

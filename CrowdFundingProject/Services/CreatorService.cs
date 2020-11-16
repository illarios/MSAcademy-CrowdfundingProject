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
                Bio = creatorOptions.Bio
            };
            
            dbContext.Creators.Add(creator);
            dbContext.SaveChanges();
            return creator;
        }

        public bool DeleteCreator(int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);
            if (creator == null) return false;
            dbContext.Creators.Remove(creator);
            return true;
        }

        public List<Creator> FindCreator(int creatorId)
        {
            List<Creator> creators = dbContext.Creators.ToList();
            return creators;
        }

        public Creator UpdateCreator(CreatorOptions creatorOptions, int creatorId)
        {
            Creator creator = dbContext.Creators.Find(creatorId);
            creator.Bio = creatorOptions.Bio;
            creator.Email = creatorOptions.Email;
            dbContext.SaveChanges();

            return creator;
        }
    }
}

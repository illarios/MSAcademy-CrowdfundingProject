using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public class BackerService : IBackerService
    { 
        private readonly AppDbContext dbContext = new AppDbContext();
        public Backer CreateBacker(BackerOptions backerOptions)
        {
            Backer backer = new Backer
            {
                Username = backerOptions.Username,
                Email = backerOptions.Email,
                IsActive = true,
                Wallet = backerOptions.Wallet,
                Tag = backerOptions.Tag
            };
            dbContext.Backers.Add(backer);
            dbContext.SaveChanges();
            return backer;

        }

        public bool DeleteBacker(int backerid)
        {
            Backer Backer = dbContext.Backers.Find(backerid);
            if (Backer == null) return false;
            dbContext.Backers.Remove(Backer);
            dbContext.SaveChanges();
            return true;

        }

        public Backer GetBackerById(int backerId)
        {
            Backer backer = dbContext.Backers.Find(backerId);
            return backer;
        }

        public Backer UpdateBacker(BackerOptions backerOptions, int backerId)
        {
            Backer backer = dbContext.Backers.Find(backerId);
            backer.Email = backerOptions.Email;
            backer.Wallet = backerOptions.Wallet;
            dbContext.SaveChanges();
            return backer;


        }

    }
}

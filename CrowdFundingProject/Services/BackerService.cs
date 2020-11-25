﻿using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using CrowdFundingProject.Options;

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
                IsBackerActive = true,
                Wallet = backerOptions.Wallet
            };
            dbContext.Backers.Add(backer);
            dbContext.SaveChanges();
            return backer;

        }

        public bool DeleteBacker(int backerid)
        {
            Backer backer = dbContext.Backers.Find(backerid);
            if (backer == null) return false;
            backer.IsBackerActive = false;
            dbContext.SaveChanges();
            return true;

        }
        public List<Backer> GetBackers()
        {
            List<Backer> backers = dbContext.Backers.Include(c => c.Tags).ToList();
            return backers;
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

        public List<Project> GetSupportingProjects(int backerId)
        {
            List<Project> projects = dbContext.Backers.Find(backerId).SupportingProjects.ToList();
            return projects;
        }

        public Backer GetBackerByUsername(string username)
        {
            Backer backer = dbContext.Backers.ToList().Find(c => c.Username == username);
            return backer;
        }
        
        public int CheckIfEmailExists(string email)
        {
            Backer bk = new Backer();
            bk = dbContext.Backers.FirstOrDefault(i => i.Email == email);
            if (bk == null) return -1;
            return bk.Id;
        }
    }
}

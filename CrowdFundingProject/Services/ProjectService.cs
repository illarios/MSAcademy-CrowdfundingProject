using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace CrowdFundingProject.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext dbContext;
        public ProjectService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Project CreateProject(int UserId, ProjectOptions projectOptions)
        {
            Creator creator = dbContext.Creators.Find(UserId);
            Project project = new Project
            {
                Title = projectOptions.Title,
                Description = projectOptions.Description,
                Category = projectOptions.Category,
                Goal = projectOptions.Goal,
                CurrentAmount = projectOptions.CurrentAmount,                
                EndDate = projectOptions.EndDate,
                Creator = creator,
                PicturePath = projectOptions.PicturePath,
                TagName = projectOptions.TagName
            };

            dbContext.Projects.Add(project);
            project.Tag = projectOptions.Tag;            
            creator.Projects.Add(project);  
            dbContext.SaveChanges();

            return project;
        }

        public bool DeleteProject(int projectId)
        {
            Project project = dbContext.Projects.Find(projectId);
            if (project == null) return false;
            dbContext.Projects.Remove(project);
            dbContext.SaveChanges();
            return true;
        }

        public List<Project> GetAllProjects()
        {
            List<Project> projects = dbContext.Projects.Include(c => c.Creator).Include(c => c.Bundles).ToList();
            return projects;
        }

        public IQueryable<Project> GetProject(GetProjectOptions opt)
        {
            var query = dbContext.Projects.AsQueryable();

            if (!string.IsNullOrWhiteSpace(opt.Title))
            {
                query = query.Where(c => c.Title.Contains(opt.Title));
            }

            else if (!string.IsNullOrWhiteSpace(opt.Description))
            {
                query = query.Where(c => c.Description.Contains(opt.Description));
            }

            else if (opt.Category!=0)
            {
                query = query.Where(c => c.Category==opt.Category);
            }

            if (opt.MaxResults == null)
            {
                query = query.Take(5);
            }
            else
            {
                query = query.Take(opt.MaxResults.Value);
            }
            return query;
        }

        public Project GetProjectById(int projectId)
        {
            Project project = dbContext.Projects.Find(projectId);
            return project;
        }

        public Project SupportProject(decimal amount, int id, int backerId, int bundleId)
        {
            var project = dbContext.Projects.Find(id);
            project.CurrentAmount += amount;
            var backer = dbContext.Backers.Find(backerId);
            backer.Wallet -= amount;

            BackerBundle backerbundle = new BackerBundle()
            {
                BackerId = backerId,
                BundleId = bundleId,
                DonateAmount = amount
            };

            dbContext.BackerBundles.Add(backerbundle);            
            dbContext.SaveChanges();
            return project;
        }

        public Project UpdateProject(ProjectOptions projectOptions, int projectId)
        {
            var project = dbContext.Projects.Find(projectId);                  
            project.Title = projectOptions.Title;
            project.Description = projectOptions.Description;
            project.Category = projectOptions.Category;
            project.Goal = projectOptions.Goal;
            project.CurrentAmount = projectOptions.CurrentAmount;           
            project.EndDate = projectOptions.EndDate;
            project.PicturePath = projectOptions.PicturePath;
            dbContext.SaveChanges();
            return project;
        }
        
    }
}

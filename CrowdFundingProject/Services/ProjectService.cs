﻿using CrowdFundingProject.Data;
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
        private readonly AppDbContext dbContext = new AppDbContext();
        
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
                IsTrending = projectOptions.IsTrending,
                EndDate = projectOptions.EndDate,
                Creator = creator,
            };

            dbContext.Projects.Add(project);
            ////   quantic expression
            creator.Projects.Add(project);

            ////
            dbContext.SaveChanges();

            //string script = string.Format("sessionStorage.projectId= '{​​​​0}​​​​';", project.Id);
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", script, true);

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
            List<Project> projects = dbContext.Projects.ToList();
            return projects;
        }

        public IQueryable<Project> GetProject(GetProjectOptions opt)
        {
           var query = dbContext.Projects.AsQueryable();

            if (!string.IsNullOrWhiteSpace(opt.Title))
            {
                query = query.Where(c => c.Title.Contains(opt.Title));
            }

            if (!string.IsNullOrWhiteSpace(opt.Description))
            {
                query = query.Where(c => c.Description.Contains(opt.Description));
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

        public Project UpdateProject(ProjectOptions projectOptions, int projectId)
        {
            Project project = dbContext.Projects.Find(projectId);
            project.Title = projectOptions.Title;
            project.Description = projectOptions.Description;
            project.Category = projectOptions.Category;
            project.Goal = projectOptions.Goal;
            project.CurrentAmount = projectOptions.CurrentAmount;
            project.IsTrending = projectOptions.IsTrending;
            project.EndDate = projectOptions.EndDate;
            dbContext.SaveChanges();
            return project;
        }
    }
}

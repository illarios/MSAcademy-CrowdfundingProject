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
    public class ProjectSerive : IProjectService
    {
        private readonly AppDbContext dbContext = new AppDbContext();

        public Project CreateProject(ProjectOptions projectOptions)
        {
            Project project = new Project
            {
                Title = projectOptions.Title,
                Description = projectOptions.Description,
                Category = projectOptions.Category,
                NotifyStatus = projectOptions.NotifyStatus,
                Goal = projectOptions.Goal,
                CurrentAmount = projectOptions.CurrentAmount,
                Media = projectOptions.Media,
                IsTrending = projectOptions.IsTrending,
                Created = projectOptions.Created,
                EndDate = projectOptions.EndDate,
                Tags = projectOptions.Tags
            };

            dbContext.Projects.Add(project);
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
            List<Project> projects = dbContext.Projects.ToList();
            return projects;
        }
        //public List<Project> GetAllProjectsbyTag(string tag)
        //{
        //    List<Project> projects = dbContext.Projects.ToList();   //   Where(c => c.Tags).Find(c => c.Name == tag).ToList();
        //    return projects;
        //}
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
            project.NotifyStatus = projectOptions.NotifyStatus;
            project.Goal = projectOptions.Goal;
            project.CurrentAmount = projectOptions.CurrentAmount;
            project.Media = projectOptions.Media;
            project.IsTrending = projectOptions.IsTrending;
            project.Created = projectOptions.Created;
            project.EndDate = projectOptions.EndDate;
            project.Tags = projectOptions.Tags;
            dbContext.SaveChanges();
            return project;
        }
    }
}

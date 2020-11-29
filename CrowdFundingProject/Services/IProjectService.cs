using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface IProjectService
    {
        Project CreateProject(int UserId, ProjectOptions projectOptions);
        Project UpdateProject(ProjectOptions projectOptions, int projectId);
        Project SupportProject(decimal amount, int id, int backerId, int bundleId);
        bool DeleteProject(int projectId);
        Project GetProjectById(int projectId);
        List<Project> GetAllProjects();    
        public IQueryable<Project> GetProject(GetProjectOptions opt);
    }
}

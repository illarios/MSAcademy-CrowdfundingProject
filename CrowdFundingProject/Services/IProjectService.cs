using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface IProjectService
    {
        Project CreateProject(ProjectOptions projectOptions);
        Project UpdateProject(ProjectOptions projectOptions, int projectId);
        bool DeleteProject(int projectId);
        Project GetProjectById(int projectId);
        List<Project> GetAllProjects();
    }
}

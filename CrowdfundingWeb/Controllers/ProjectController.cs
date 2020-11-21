using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CrowdfundingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService projectService;

        public ProjectController(IProjectService _projectService, ILogger<ProjectController> logger)
        {
            projectService = _projectService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public Project GetProjectById(int id)
        {
            Project project = projectService.GetProjectById(id);
            return project;
        }

        [HttpGet("all")]
        public List<Project> GetProjects()
        {
            List<Project> projects = projectService.GetAllProjects();
            return projects;
        }

        [HttpPost("create")]
        public Project CreateProject(ProjectOptions projectOptions)
        {
            Project project = projectService.CreateProject(projectOptions);
            return project;
        }

        [HttpPut("update/{id}")]
        public Project UpdateProject(ProjectOptions projectOptions, int id)
        {
            Project project = projectService.UpdateProject(projectOptions, id);
            return project;
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteProject(int id)
        {
            return projectService.DeleteProject(id);
        }
    }
}

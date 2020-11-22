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
        private readonly IBackerService backerService;
        private readonly IBundleService bundleService;

        public ProjectController(IProjectService _projectService, ILogger<ProjectController> logger,
            IBackerService _backerService, IBundleService _bundleService)
        {
            projectService = _projectService;
            bundleService = _bundleService;
            backerService = _backerService;
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

        [HttpGet("my/backers")]
        public List<Backer> GetBackers()
        {
            List<Backer> backers = backerService.GetBackers();
            return backers;
        }

        [HttpGet("my/bundles")]
        public List<Bundle> GetBundles()
        {
            List<Bundle> bundles = bundleService.GetBundles();
            return bundles;
        }
    }
}

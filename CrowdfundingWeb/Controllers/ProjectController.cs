using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using CrowdfundingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly AppDbContext dbContext = new AppDbContext();

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

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var opt = new GetProjectOptions()
        //    {
        //        MaxResults = 3
        //    };

        //    var customers = customers_
        //        .GetCustomers(options)
        //        .ToList();

        //    return View(customers);
        //}

        [HttpPost("create")]
        public Project CreateProject([FromBody] ProjectfromFormModel projectModel)
        {
            ProjectOptions projectOpt = new ProjectOptions
            {
                Title = projectModel.Title,
                Description = projectModel.Description,
                Goal = projectModel.Goal,
                CurrentAmount = 0,
                EndDate = projectModel.EndDate.ToString(),
                Category = projectModel.Category
            };

            Project project = projectService.CreateProject(projectModel.Id, projectOpt);

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

        //[HttpGet("{id}/bundles")]
        //public List<Bundle> GetBundles(int id)
        //{

        //    List<Bundle> bundles = bundleService.GetBundlesOfProjects(int projectId)();
        //    return bundles;
        //}
        //[HttpPost("bundles")]
        //public List<Bundle> AddBundles(int userid)
        //{
        //    List<Bundle> bundles = bundleService.GetBundlesOfProjects(int projectId)();
        //    return bundles;
        //}
    }
}

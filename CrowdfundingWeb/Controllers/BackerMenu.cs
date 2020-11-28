using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using CrowdfundingWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingWeb.Controllers
{
    public class BackerMenu : Controller
    {
        private readonly IProjectService projects_;
        public BackerMenu(IProjectService projects)
        {
            projects_ = projects;
        }

        public IActionResult BDashboard()
        {
            return View();
        }  

        public IActionResult ProjectView([FromRoute]int id)
        {
            Project project = projects_.GetProjectById(id);
            ProjectfromFormModel model = new ProjectfromFormModel { 
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Goal = project.Goal,
                Category = project.Category,
                EndDate = project.EndDate
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult BrowseProjects()
        {
            var options = new GetProjectOptions()
            {
                MaxResults = 3
            };

            var projects = projects_
                .GetProject(options)
                .ToList();

            return View(projects);
        }

        [HttpPost]
        public IActionResult GetProjects([FromBody] GetProjectOptions options)
        {
            var results = projects_
                .GetProject(options)                
                .ToList();

            return Ok(results);
        }
    }
}


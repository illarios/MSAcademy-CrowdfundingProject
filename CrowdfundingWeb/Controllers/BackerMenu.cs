using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
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

        public IActionResult ProjectView()
        {
            return View();
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


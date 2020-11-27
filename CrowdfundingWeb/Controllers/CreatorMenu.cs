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
    public class CreatorMenu : Controller
    {
        
        private readonly ICreatorService creatorService;
        private readonly IBackerService backerService;
        private readonly IProjectService projectService;

        public CreatorMenu(ICreatorService _creatorService, IBackerService _backerService, IProjectService _projectService)

        {
            creatorService = _creatorService;
            backerService = _backerService;
            projectService = _projectService;
           
        }
        public IActionResult CDashboard()
        {
            List<Project> projects = projectService.GetAllProjects();
            ProjectListModel projectListModel = new ProjectListModel
            {
                Projects = projects
            };
            return View(projectListModel);
        }

        [HttpPost]
        public IActionResult EditProfile(int x)
        {
            CreatorOptions creatorOpt = creatorService.GetCreatorById(x);
            CreatorOptionModel model = new CreatorOptionModel { Creatoroptions = creatorOpt };

            return View(model);
        }

        public IActionResult CreatorProjects()
        {
            return View();
        }
    }
}

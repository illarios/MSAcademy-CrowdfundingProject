using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using CrowdfundingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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
        
//        [HttpPost]
//        public IActionResult EditProfile()
//        {
////            CreatorOptions creatorOpt = creatorService.GetCreatorById(Int32.Parse(options.UserId));
////            CreatorOptionModel model = new CreatorOptionModel { Creatoroptions = creatorOpt };

//            return Ok();
//        }
        
        [HttpGet]
        public IActionResult EditProfileNew([FromQuery]int id)
        {
            var creatorOpt = creatorService.GetCreatorById(id);
            var model = new CreatorOptionModel { Creatoroptions = creatorOpt };

            return View("EditProfile", model);
        }
        
        
        public IActionResult CreatorProjects()
        {
            return View();
        }
    }
}

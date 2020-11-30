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
using CrowdFundingProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundingWeb.Controllers
{
    public class CreatorMenu : Controller
    {
        
        private readonly ICreatorService creatorService;
        private readonly IBackerService backerService;
        private readonly IProjectService projectService;
        private readonly AppDbContext dbContext = new AppDbContext();

        public CreatorMenu(ICreatorService _creatorService, IBackerService _backerService, IProjectService _projectService)
        

        {
            creatorService = _creatorService;
            backerService = _backerService;
            projectService = _projectService;
           
        }
        
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
        
        public IActionResult CDashBoard([FromQuery]int id)
        {
            var projs = dbContext.Projects
                .Where(pr => pr.Creator.Id == id)
                .Include(pr => pr.Bundles)
                .Include(pr => pr.BackerBundle)   //<----
                .ToList();

            return View(projs);
        }
    }
}

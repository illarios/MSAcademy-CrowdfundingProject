using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrowdfundingWeb.Models;
using CrowdFundingProject.Services;
using CrowdFundingProject.Models;

namespace CrowdfundingWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICreatorService creatorService;

        public HomeController(ICreatorService _creatorService, ILogger<HomeController> logger)

        {
            creatorService = _creatorService;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }
   

        public IActionResult DisplayCreators()
        {
            List<Creator> creators = creatorService.GetCreators();
            CreatorListModel creatorsListModel = new CreatorListModel
            {
                Creators = creators
            };
            return View(creatorsListModel);
        }

        public IActionResult DisplayCreatorProjects()
        {
            Creator creator = creatorService.GetCreatorById(1);  //TODO Get the creatorID by the login session and HIS projects to display
            ProjectListModel projectListModel = new ProjectListModel
            {
                Projects = creator.Projects //.ToList();
            };
            return View(projectListModel);
        }

        public IActionResult CreateProfile()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult LoginBacker()
        {
            return View();
        }

        public IActionResult LoginCreator()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

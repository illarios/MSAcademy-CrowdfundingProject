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
        private readonly IBackerService backerService; 
 
        public HomeController(ICreatorService _creatorService, IBackerService _backerService, ILogger<HomeController> logger)

        {
            creatorService = _creatorService;
            backerService = _backerService;
            _logger = logger;
        }
        
        [HttpPost]
        public IActionResult FunctionL([FromBody] LoginModel options)
        {
            var id = creatorService.CheckIfEmailExists(options.Email);
            if (id != -1) 
            {
                return Ok(new {
                    userId = id
                });
            }

            return Forbid();
        }
        
        [HttpPost]
        public IActionResult FunctionLbk([FromBody] LoginModel options)
        {
            var id = backerService.CheckIfEmailExists(options.Email);
            if (id != -1) 
            {
                return Ok(new {
                    userId = id
                });
            }

            return Forbid();
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

       /* public IActionResult DisplayCreatorProjects()
        {
            Creator creator = creatorService.GetCreatorById(1);  //TODO Get the creatorID by the login session and HIS projects to display
            ProjectListModel projectListModel = new ProjectListModel
            {
                Projects = creator.Projects //.ToList();
            };
            return View(projectListModel);
        }*/

        public IActionResult CreateProfile()
        {
            return View();
        }

        public IActionResult CreateProfileBacker()
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

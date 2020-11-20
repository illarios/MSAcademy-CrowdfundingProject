using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrowdfundingWeb.Models;
using CrowdFundingProject.Services;

namespace CrowdfundingWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICreatorService creatorService;
        private readonly IBackerService backerService;

        public HomeController(ILogger<HomeController> logger, ICreatorService _creatorService,IBackerService _backerService)

        {
            _logger = logger;
            creatorService = _creatorService;
            backerService = _backerService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Creator()
        {
            return View();
        }

        public IActionResult Backer()
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

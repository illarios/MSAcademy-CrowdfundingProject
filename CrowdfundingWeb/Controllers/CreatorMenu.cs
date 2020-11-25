using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingWeb.Controllers
{
    public class CreatorMenu : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult CreatorProjects()
        {
            return View();
        }
    }
}

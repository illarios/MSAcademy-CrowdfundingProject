using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingWeb.Controllers
{
    public class BackerMenu : Controller
    {
        public IActionResult BDashboard()
        {
            return View();
        }
    }
}

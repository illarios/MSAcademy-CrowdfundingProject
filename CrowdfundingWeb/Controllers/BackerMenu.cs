using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using CrowdfundingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundingWeb.Controllers
{
    public class BackerMenu : Controller
    {
        private readonly ICreatorService creatorService;
        private readonly IBackerService backerService;
        private readonly IProjectService projects_;
        private readonly IBundleService bundles_;
        private readonly AppDbContext dbContext = new AppDbContext();

        public BackerMenu(ICreatorService _creatorService, IBackerService _backerService, IProjectService projects, IBundleService bundles)
        {
            creatorService = _creatorService;
            backerService = _backerService;
            projects_ = projects;
            bundles_ = bundles;
        }
        public IActionResult EditProfileBacker()
        {
            return View();
        }

        public IActionResult ProjectView([FromRoute]int id)
        {
            Project project = projects_.GetProjectById(id);
            List<Bundle> bundles = bundles_.GetBundlesOfProjects(id);       
            ProjectWithBundlesModel model = new ProjectWithBundlesModel
            {               
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Goal = project.Goal,
                Category = project.Category,
                EndDate = project.EndDate,
                Bundles = bundles,
                PicturePath = project.PicturePath,
                Progress = project.Progress,
                IsTrending = project.IsTrending,
                Tag = project.Tag,
                TagName = project.TagName,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult BrowseProjects()
        {
            var options = new GetProjectsNoOptions()
            {
                MaxResults = 100
            };

            var projects = projects_
                .GetAllProjects()
                .Take(100)
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

        [HttpGet]
        public IActionResult EditProfileNew([FromQuery] int id)
        {
            var backerOpt = backerService.GetBackerById(id);
            var model = new BackerOptionModel { Backeroptions = backerOpt };

            return View("EditProfileBacker", model);
        }
       
        [HttpGet]
        public IActionResult BDashboard([FromQuery] int id)
        {
            var  projectIds = (from p in dbContext.BackerBundles
                join e in dbContext.Bundles
                    on p.BundleId equals e.Id
                where p.BackerId == id
                select new
                {
                    projId = e.Project.Id
                }).Distinct().ToList();

            var prids = new List<int>();
            foreach ( var child in projectIds )
            {
                prids.Add(child.projId);
            };

            var projects = dbContext.Projects
                .Where(l => prids.Any(id => id == l.Id))
                .Include(c => c.Bundles)
                .Include(c => c.Creator)
                .ToList();
            
            return View(projects);
        }
    }
}


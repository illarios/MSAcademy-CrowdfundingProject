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
        private readonly IBundleService bundleService;
        private readonly AppDbContext dbContext = new AppDbContext();

        public CreatorMenu(ICreatorService _creatorService, IBackerService _backerService, IProjectService _projectService, IBundleService _bundleService)
        

        {
            creatorService = _creatorService;
            backerService = _backerService;
            projectService = _projectService;
            bundleService = _bundleService;

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
        {   List<ProjectWithBackers> mod = new List<ProjectWithBackers>();
            
            var projs = dbContext.Projects
                .Where(pr => pr.Creator.Id == id)
                .Include(pr => pr.Bundles)
                .Include(pr => pr.BackerBundle)   //<----
                .ToList();

            if (projs.Count()>0)
            {foreach (var item in projs)
                {
                    ProjectWithBackers ind = new ProjectWithBackers();
                    ind.Id = item.Id;
                    ind.Title = item.Title;
                    ind.Bundles = item.Bundles;
                    ind.EndDate = item.EndDate;
                    ind.Category = item.Category;
                    ind.CurrentAmount = item.CurrentAmount;
                    ind.Progress = item.Progress;
                    var person = (from p in dbContext.Bundles
                        join e in dbContext.BackerBundles
                            on p.Id equals e.BundleId
                        where p.Project.Id == item.Id
                        select new {ID = e.BackerId}).Distinct().Count();
                    ind.BackerCount = person;
                    mod.Add(ind); 
                }
            }
            return View(mod);
        }
        
        public IActionResult ProjectView([FromRoute]int id)
        {
            Project project = projectService.GetProjectById(id);
            List<Bundle> bundles = bundleService.GetBundlesOfProjects(id);       
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
    }
}

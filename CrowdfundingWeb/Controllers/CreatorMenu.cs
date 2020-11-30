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
        private readonly IProjectService projects_;
        private readonly IBundleService bundles_;
        private readonly AppDbContext dbContext = new AppDbContext();

        public CreatorMenu(ICreatorService _creatorService, IBackerService _backerService, IProjectService projects, IBundleService bundles)
        

        {
            creatorService = _creatorService;
            backerService = _backerService;
            projects_ = projects;
            bundles_ = bundles;
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
        public IActionResult ProjectView([FromRoute] int id)
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
    }
}

using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using CrowdfundingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CrowdfundingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService projectService;
        private readonly IBackerService backerService;
        private readonly IBundleService bundleService;
        private readonly AppDbContext dbContext = new AppDbContext();
        private readonly ITagService tagService;
        private readonly IWebHostEnvironment hostingEnvironment;


        public ProjectController(IProjectService _projectService, ILogger<ProjectController> logger,
            IBackerService _backerService, IBundleService _bundleService, ITagService _tagService, IWebHostEnvironment _hostingEnvironment)
        {
            projectService = _projectService;
            bundleService = _bundleService;
            backerService = _backerService;
            tagService = _tagService;
            hostingEnvironment = _hostingEnvironment;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public Project GetProjectById(int id)
        {
            Project project = projectService.GetProjectById(id);
            return project;
        }

        [HttpGet("all")]
        public List<Project> GetProjects()
        {
            List<Project> projects = projectService.GetAllProjects();
            return projects;
        }

        [HttpPost("create")]
        public int CreateProject([FromForm] ProjectfromFormModel projectModel)
        {

            /////////////////
            var formFile = projectModel.Picture;
            var filename = projectModel.Picture.FileName;
            if (formFile.Length > 0)
            {
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploadedimages", filename);
                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                }
            }
            ///////////////////////

            Tag tag = tagService.GetTagbyId(projectModel.Category);
            ProjectOptions projectOpt = new ProjectOptions
            {
                Title = projectModel.Title,
                Description = projectModel.Description,
                Goal = projectModel.Goal,
                CurrentAmount = 0,
                EndDate = projectModel.EndDate.ToString(),
                Category = projectModel.Category,
                PicturePath = filename,
                Tag = tag,
                TagName = tag.Name
            };

            projectModel.PicturePath = filename;

            Project project = projectService.CreateProject(projectModel.Id, projectOpt);
            //var taglist = projectModel.Tags;
            //for(var i=0;i<taglist.Count; i++)
            //{
            //    Tag tag = tagService.GetTagbyId(taglist[i]);
            //    dbContext.Projects.Find(project).Tags.Add(tag);
            //}

            dbContext.SaveChanges();

            return project.Id;
        }

        [HttpPut("update/{id}")]
        public Project UpdateProject(ProjectOptions projectOptions, int id)
        {
            Project project = projectService.UpdateProject(projectOptions, id);
            return project;
        }
        
        [HttpPut("support")]
        public Project SupportProject([FromBody] ProjectSupportModel supportModel)
        {
            Project project = projectService.SupportProject(supportModel.Amount, supportModel.Id, supportModel.BackerId, supportModel.BundleId);
            return project;
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteProject(int id)
        {
            return projectService.DeleteProject(id);
        }

        [HttpGet("my/backers")]
        public List<Backer> GetBackers()
        {
            List<Backer> backers = backerService.GetBackers();
            return backers;
        }

        //[HttpGet("{id}/bundles")]
        //public List<Bundle> GetBundles(int id)
        //{

        //    List<Bundle> bundles = bundleService.GetBundlesOfProjects(int projectId)();
        //    return bundles;
        //}

        [HttpPost("bundles")]
        public bool AddBundleS([FromBody] BundleListModel bundleList)
        {
            int projectId = bundleList.projectId;
            List<Bundle> bundles = bundleList.Bundles;
            foreach(var bundle in bundles)
            {
                if (bundle != null)
                {
                    BundleOptions bundleOpt = new BundleOptions
                    {
                        Prize = bundle.Prize,
                        Description = bundle.Description
                    };
                    Bundle addedBundle = bundleService.AddBundle(bundleOpt, projectId);
                }
            }
            
            return true;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using CrowdfundingWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrowdfundingWeb.Controllers
{
    public class BackerMenu : Controller
    {
        private readonly ICreatorService creatorService;
        private readonly IBackerService backerService;
        private readonly IProjectService projects_;
        public BackerMenu(ICreatorService _creatorService, IBackerService _backerService, IProjectService projects)
        {
            creatorService = _creatorService;
            backerService = _backerService;
            projects_ = projects;
        }

        public IActionResult BDashboard()
        {
            return View();
        }

        public IActionResult EditProfileBacker()
        {
            return View();
        }

        public IActionResult ProjectView([FromRoute]int id)
        {
            Project project = projects_.GetProjectById(id);
            ProjectfromFormModel model = new ProjectfromFormModel { 
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Goal = project.Goal,
                Category = project.Category,
                EndDate = project.EndDate
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult BrowseProjects()
        {
            var options = new GetProjectOptions()
            {
                MaxResults = 100
            };

            var projects = projects_
                .GetProject(options)
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

    }
}


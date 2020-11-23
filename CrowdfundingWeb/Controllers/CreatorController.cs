﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using CrowdfundingWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrowdfundingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ControllerBase
    {
        private readonly ILogger<CreatorController> _logger;
        private readonly ICreatorService creatorService; // = new CreatorService();

        public CreatorController(ICreatorService _creatorService, ILogger<CreatorController> logger)
        {
            creatorService = _creatorService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public Creator GetCreatorById(int id)
        {
            Creator creator = creatorService.GetCreatorById(id);
            return creator;
        }

        [HttpGet("user")]
        public Creator GetCreatorByUsername([FromQuery]string username)
        {
            Creator creator = creatorService.GetCreatorByUsername(username);
            return creator;
        }

        [HttpGet("all")]
        public List<Creator> GetCreators()
        {
            List<Creator> creators = creatorService.GetCreators();
            return creators;
        }

        [HttpGet("my/projects")]
        public List<Project> GetAllProjects(int id)
        {
            List<Project> projects = creatorService.GetAllProjects(id);
            return projects;
        }

        [HttpPost("create")]
        public Creator CreateCreator([FromForm] CreatorWithFileModel creatormodelOptWithFileModel)
        {
            CreatorOptions creatoropt = new CreatorOptions
            {
                Username = creatormodelOptWithFileModel.Username,
                Email = creatormodelOptWithFileModel.Email,
                Bio = creatormodelOptWithFileModel.Bio
            };

            Creator creator = creatorService.CreateCreator(creatoropt);
            return creator;
        }

        [HttpPut("update/{id}")]
        public Creator UpdateCreator(CreatorOptions creatorOptions, int id)
        {
            Creator creator = creatorService.UpdateCreator(creatorOptions, id);
            return creator;
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteCreator(int id)
        {
            return creatorService.DeleteCreator(id);
        }
    }
}

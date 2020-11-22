using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CrowdfundingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackerController : ControllerBase
    {
        private readonly ILogger<BackerController> _logger;
        private readonly IBackerService backerService;

        public BackerController(IBackerService _backerService, ILogger<BackerController> logger)
        {
            backerService = _backerService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public Backer GetBackerById(int id)
        {
            Backer backer = backerService.GetBackerById(id);
            return backer;
        }

        [HttpGet("user")]
        public Backer GetBackerByUsername([FromQuery]string username)
        {
            Backer backer = backerService.GetBackerByUsername(username);
            return backer;
        }        

        [HttpGet("all")]
        public List<Backer> GetBackers()
        {
            List<Backer> backers = backerService.GetBackers();
            return backers;
        }

        [HttpGet("my/projects")]
        public List<Project> GetSupportingProjects(int id)
        {
            List<Project> projects = backerService.GetSupportingProjects(id);
            return projects;
        }

        [HttpPost("create")]
        public Backer CreateBacker(BackerOptions backerOptions)
        {
            Backer backer = backerService.CreateBacker(backerOptions);
            return backer;
        }

        [HttpPut("update/{id}")]
        public Backer UpdateBacker(BackerOptions backerOptions, int id)
        {
            Backer backer = backerService.UpdateBacker(backerOptions, id);
            return backer;
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteBacker(int id)
        {
            return backerService.DeleteBacker(id);
        }
    }
}

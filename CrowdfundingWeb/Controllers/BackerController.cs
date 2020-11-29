using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using CrowdFundingProject.Services;
using CrowdfundingWeb.Models;
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
        public BackerOptions GetBackerById(int id)
        {
            BackerOptions backerOpt = backerService.GetBackerById(id);
            return backerOpt;
        }

        [HttpGet("user")]
        public Backer GetBackerByUsername([FromQuery]string username)
        {
            Backer backer = backerService.GetBackerByUsername(username);
            return backer;
        }
        [HttpPost("checkwallet")]
        public bool CheckWallet([FromBody] BackerWalletModel backerWalletModel)
        {
            BackerOptions backer = backerService.GetBackerById(backerWalletModel.BackerId);
            if (backer.Wallet >= backerWalletModel.AmountGiven)
                return true;
            else
                return false;
        }

        [HttpGet("all")]
        public List<Backer> GetBackers()
        {
            List<Backer> backers = backerService.GetBackers();
            return backers;
        }

        [HttpPost]
        public BackerOptions CreateBacker([FromBody] BackerWithFileModel backerOptWithFileModel)
        {
            BackerOptions backeropt = new BackerOptions
            {
                Username = backerOptWithFileModel.Username,
                Email = backerOptWithFileModel.Email,
                Wallet = backerOptWithFileModel.Wallet
            };
            BackerOptions backer = backerService.CreateBacker(backeropt);
            return backer;
        }

        [HttpPut("update/{id}")]
        public Backer UpdateBacker(BackerOptions backerOptions, int id)
        {
            Backer backer = backerService.UpdateBacker(backerOptions, id);
            return backer;
        }

        [HttpPut("delete/{id}")]
        public bool DeleteBacker(int id)
        {
            return backerService.DeleteBacker(id);
        }
    }
}

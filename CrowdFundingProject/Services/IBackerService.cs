using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface IBackerService
    {
        Backer CreateBacker(BackerOptions backerOptions);
        Backer GetBackerById(int backerId);
        List<Backer> GetBackers();
        List<Project> GetSupportingProjects(int backerId);
        Backer UpdateBacker(BackerOptions backerOptions, int backerId);
        bool DeleteBacker(int backerId);
        Backer GetBackerByUsername(string username);
        public int CheckIfEmailExists(string email);
    }
}

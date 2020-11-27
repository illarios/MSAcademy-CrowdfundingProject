using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface ICreatorService
    {
        CreatorOptions CreateCreator(CreatorOptions creatorOptions);
        CreatorOptions UpdateCreator(CreatorOptions creatorOptions, int creatorId);
        List<Creator> GetCreators();
        List<Project> GetAllProjects(int creatorId);
        CreatorOptions GetCreatorById(int creatorId);
        bool DeleteCreator(int creatorId);
        Creator GetCreatorByUsername(string username);
        int CheckIfEmailExists(string email);
    }

}

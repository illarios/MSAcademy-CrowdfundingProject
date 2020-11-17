using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface ICreatorService
    {
        Creator CreateCreator(CreatorOptions creatorOptions);
        Creator UpdateCreator(CreatorOptions creatorOptions, int creatorId);
        List<Creator> GetCreators();
        Creator GetCreatorById(int creatorId);
        bool DeleteCreator(int creatorId);
    }
}

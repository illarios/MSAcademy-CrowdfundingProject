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
        List<Creator> FindCreator(int creatorId);
        bool DeleteCreator(int creatorId);
    }
}

using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface ITagService
    {
        public Tag GetTagbyId(int tagId);
    }
}

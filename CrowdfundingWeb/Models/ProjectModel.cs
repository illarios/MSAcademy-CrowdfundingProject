using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingWeb.Models
{
    public class ProjectModel
    {
        public List<Project> Projects { get; set; }
        public Project Project { get; set; }
    }
}

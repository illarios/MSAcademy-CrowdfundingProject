using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
    public class GetProjectOptions
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Category { get; set; }
        public int? MaxResults { get; set; }
    }

    public class GetProjectsNoOptions
    {
        public int? MaxResults { get; set; }
    }
}

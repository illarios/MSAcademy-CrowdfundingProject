using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
    public class GetProjectOptions
    {
        public string Title { get; set; }
        public string Description { get; set; }        
        public int? MaxResults { get; set; }
    }
}

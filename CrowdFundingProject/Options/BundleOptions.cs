using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
    public class BundleOptions
    {
        public decimal Prize { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
    }
}

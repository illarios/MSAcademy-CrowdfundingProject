using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Project> Projects { get; set; }
        public Backer Backer { get; set; }
        public List<Bundle> Bundles { get; set; }
    }
}

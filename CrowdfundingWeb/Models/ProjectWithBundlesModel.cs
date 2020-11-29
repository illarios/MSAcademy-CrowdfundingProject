using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingWeb.Models
{
    public class ProjectWithBundlesModel
    {       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public decimal Goal { get; set; }
        public string EndDate { get; set; }
        public List<Bundle> Bundles { get; set; }
        public bool IsTrending { get; set; }
        public decimal Progress { get; set; }
        public Tag Tag { get; set; }
        public string TagName { get; set; }
        public string PicturePath { get; set; }
    }
}

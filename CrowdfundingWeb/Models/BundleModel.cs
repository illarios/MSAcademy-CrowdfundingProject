using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingWeb.Models
{
    public class BundleModel
    {
        public Bundle Bundle { get; set; }
    }
    public class BundleListModel
    {
        public int projectId { get; set; }
        public List<Bundle> Bundles { get; set; }
    }       
}

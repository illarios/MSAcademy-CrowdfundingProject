using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingWeb.Models
{
    public class BackerModel
    {
        public List<Backer> Backers { get; set; }
        public Backer Backer { get; set; }
    }
}

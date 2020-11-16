using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
    public class CartOptions
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public Backer Backer { get; set; }
        public Bundle Bundle { get; set; }
    }
}

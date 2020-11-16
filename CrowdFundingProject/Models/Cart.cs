using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public Backer Backer { get; set; }
        public Bundle Bundle { get; set; }
    }
}

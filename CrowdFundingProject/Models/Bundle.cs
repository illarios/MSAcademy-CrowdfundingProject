using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Models
{
    public class Bundle
    {
        public int Id { get; set; }
        public decimal Prize { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
    }
}

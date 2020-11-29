using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
    public class ProjectOptions
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public decimal Goal { get; set; }
        public decimal CurrentAmount { get; set; }
        public bool IsTrending { get; set; }
        public string EndDate { get; set; }
        public string PicturePath { get; set; }
        public string TagName { get; set; }
        public Tag Tag { get; set; }
    }
}

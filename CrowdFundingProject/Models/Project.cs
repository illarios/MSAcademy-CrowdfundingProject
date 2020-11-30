using System;
using System.Collections.Generic;

namespace CrowdFundingProject.Models
{
    public class Project
    {
        //Primary key
        public int Id { get; set; }
        //Attributes
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public decimal Goal { get; set; }
        public decimal CurrentAmount { get; set; }
        public bool IsTrending => (Progress > 50);
        public decimal Progress => Math.Round((CurrentAmount / Goal)*100);
        public string EndDate { get; set; }
        public string PicturePath { get; set; }
        public string TagName { get; set; }

        //Foreign Key
        public Creator Creator { get; set; }
        public List<Bundle> Bundles { get; set; }
        
        public List<BackerBundle> BackerBundle { get; set; }
        public Tag Tag { get; set; }
    }
}
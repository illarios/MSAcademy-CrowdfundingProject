using CrowdFundingProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingWeb.Models
{
    public class ProjectModel
    {
        public Project Project { get; set; }
    }
    public class ProjectfromFormModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public decimal Goal { get; set; }
        public string EndDate { get; set; }
        public Tag Tag { get; set; }
        public IFormFile Picture { get; set; }
        public string PicturePath { get; set; }
    }
    public class ProjectListModel
    {
        public List<Project> Projects { get; set; }
    }
    public class ProjectSupportModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int BackerId { get; set; }
        public int BundleId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Models
{
    public class Backer
    { 
        public int Id { get; set; }
        public string Username { get; set; }
        public decimal Wallet { get; set; }
        public string Email { get; set; }
        public bool IsBackerActive { get; set; }
        public List<Project> SupportingProjects { get; set; }
        public List<Tag> Tags { get; set; }
    }
}

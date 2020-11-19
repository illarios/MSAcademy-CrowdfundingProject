using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
   public class BackerOptions
    {
        public string Username { get; set; }
        public decimal Wallet { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<Tag> Tags { get; set; }
    }
}

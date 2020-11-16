using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
   public class BackerOptions
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public decimal Wallet { get; set; }
        public string Email { get; set; }
        public Boolean IsActive { get; set; }
        public List<string> Tag { get; set; }
    }
}

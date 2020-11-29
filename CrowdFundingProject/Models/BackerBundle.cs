using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Models
{
    public class BackerBundle
    { 
        public int Id { get; set; }

        public int BackerId { get; set; }
        
        public int BundleId { get; set; }

        public Backer backer { get; set; }
        
        public Bundle bundle { get; set; }

        public decimal DonateAmount { get; set; }


    }
}

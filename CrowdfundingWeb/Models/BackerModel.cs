using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingWeb.Models
{
    public class BackerListModel
    {
        public List<Backer> Backers { get; set; }
    }

    public class BackerModel 
    {
        public Backer Backer { get; set; }
    }

    public class BackerOptionModel
    {
        public BackerOptions Backeroptions { get; set; }
    }

    public class BackerWithFileModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Wallet { get; set; }
    }
    public class BackerWalletModel
    {
        public int BackerId { get; set; }
        public decimal AmountGiven { get; set; }
    }

}

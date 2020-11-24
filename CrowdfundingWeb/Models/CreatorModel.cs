using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingWeb.Models
{
    public class CreatorListModel
    {
        public List<Creator> Creators { get; set; }
    }
    public class CreatorModel
    {
        public Creator Creator { get; set; }
    }
    public class CreatorOptionModel
    {
        public CreatorOptions Creatoroptions { get; set; }
    }
    public class CreatorWithFileModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
    }

}

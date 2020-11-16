using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
    public class ProjectOptions
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool NotifyStatus { get; set; }
        public decimal Goal { get; set; }
        public decimal CurrentAmount { get; set; }
	    public object Media { get; set; }
	    public bool IsTrending { get; set; }
	    public DateTimeOffset Created { get; set; }
	    public DateTimeOffset EndDate { get; set; }
	    public List<string> Tags { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Options
{
    public class CreatorOptions
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public bool IsActive { get; set; }
    }
}

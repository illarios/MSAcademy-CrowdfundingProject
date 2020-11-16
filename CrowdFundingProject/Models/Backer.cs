﻿using System;
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
        public Boolean IsActive { get; set; }
        public List<Project> SupportingProjects { get; set; }
        public List<string> Tag { get; set; }
        public Cart Cart { get; set; }
    }
}

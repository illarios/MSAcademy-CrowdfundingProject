﻿using System;
using System.Collections.Generic;

namespace CrowdFundingProject.Models
{
    public class Project
    {   
        //Primary key
        public int Id { get; set; }
        //Attributes
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public decimal Goal { get; set; }
        public decimal CurrentAmount { get; set; }
        public bool IsTrending { get; set; }
        public string Created { get; set; }
        public string EndDate { get; set; }

         //Foreign Key
         public Creator Creator { get; set; }
         public List<Bundle> Bundles {get; set; }
         public List<Backer> Backers { get; set; }
    }
}
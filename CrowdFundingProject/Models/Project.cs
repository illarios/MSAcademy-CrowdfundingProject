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
        public bool NotifyStatus { get; set; }
        public decimal Goal { get; set; }
        public decimal CurrentAmount { get; set; }
        public object Media { get; set; }
        public bool IsTrending { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public List<Tag> Tags { get; set; }

         //Foreign Key
         public Creator Creator { get; set; }
         public List<Bundle> Bundles {get; set; }
         public List<Backer> Backers { get; set; }
    }
}
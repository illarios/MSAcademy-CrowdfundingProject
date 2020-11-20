using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Models
{
    public class Creator
    {
        //Primary key
        public int Id { get; set; }
        //Attributes
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public bool IsActive { get; set; }
        //Foreign Key
        public  List<Project> Projects { get; set; }
    }
}

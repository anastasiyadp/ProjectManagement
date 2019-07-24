using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class CreateProjectViewModel
    {
        public Project Project { get; set; }
        public Role Role { get; set; }

        public CreateProjectViewModel(Project project, Role role) //create a constructor 
        {
            this.Project = project;           
            this.Role = role;
        }
    }
}
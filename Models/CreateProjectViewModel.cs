using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.Models
{
    public class CreateProjectViewModel
    {
        public Project Project { get; set; }
        public Role Role { get; set; }
    }
}
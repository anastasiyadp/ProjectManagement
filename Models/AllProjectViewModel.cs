using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class AllProjectViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public FilterProjectModel FilterProjectModel { get; set; }
        public SortProjectModel SortProjectModel { get; set; }
    }
}
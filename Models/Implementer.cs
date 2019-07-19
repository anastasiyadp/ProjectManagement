using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Implementer
    {
        public int ImplementerId { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Project> Projects { get; set; }
    }
}
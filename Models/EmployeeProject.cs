using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class EmployeeProject
    {
        [Key, ForeignKey("Employee")]
        [Column(Order = 0)]
        public int EmployeeId { get; set; }

        [Key, ForeignKey("Project")]
        [Column(Order = 1)]
        public int ProjectId { get; set; }

        public Role Role { get; set; }

        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
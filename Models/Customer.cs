using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Требуется название компании")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 30 символов")]
        public string Name { get; set; }

        public virtual List<Project> Projects { get; set; }
    }
}
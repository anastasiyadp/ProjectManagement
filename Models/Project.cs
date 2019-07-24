using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Требуется название проекта")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Требуется дата начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Требуется дата окончания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FinishDate { get; set; }

        [Range(1, 10, ErrorMessage = "приоритет должен быть от 1 до 10")]
        public int Priority { get; set; }

        //ссылка на заказчика
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //Ссылка на таблицу связей с доп. атрибутами
        public virtual List<EmployeeProject> EmployeeProjects { get; set; }
        // public virtual List<Employee> Employees { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "Введите имя")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 20 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 20 символов")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите отчество")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 20 символов")]
        public string Patronymic { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        public int ImplementerId { get; set; }
        public Implementer Implementer { get; set; }

        //Ссылка на таблицу связей с доп. атрибутами
        public virtual List<EmployeeProject> EmployeeProjects { get; set; }
        // public List<Project> Projects { get; set; }
    }
}
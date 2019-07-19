using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public int ImplementerId { get; set; }
        public Implementer Implementer { get; set; }

        // список проектов, которые выполняет данный сотрудник
        public List<Project> Projects { get; set; }
    }
}
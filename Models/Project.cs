using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Priority { get; set; }

        //ссылка на заказчика
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //ссылка на исполнителя
       // public int ImplementerId { get; set; }
        public Implementer Implementer { get; set; }

        //Ссылка на сотрудников
        public virtual List<Employee> Employees { get; set; }
    }
}
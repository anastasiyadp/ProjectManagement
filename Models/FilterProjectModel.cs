using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.Models
{
    public class FilterProjectModel
    {
        public FilterProjectModel(List<Customer> customers, int? customer, DateTime? start, DateTime? finish)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            customers.Insert(0, new Customer { Name = "Все", CustomerId = 0 });
            Customers = new SelectList(customers, "CustomerId", "Name", customer);
            SelectedCustomer = customer;
            this.start = start;
            this.finish = finish;
        }
        public SelectList Customers { get; private set; } // список компаний
        public int? SelectedCustomer { get; private set; }   // выбранная компания
        [DataType(DataType.Date)]
        [Display(Name = "С")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? start { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "по")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? finish { get; set; }
    }
}
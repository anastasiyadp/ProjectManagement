using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.Models
{
    public class FilterProjectModel
    {
        public FilterProjectModel(List<Customer> customers, int? customer)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            customers.Insert(0, new Customer { Name = "Все", CustomerId = 0 });
            Customers = new SelectList(customers, "CustomerId", "Name", customer);
            SelectedCustomer = customer;
        }
        public SelectList Customers { get; private set; } // список компаний
        public int? SelectedCustomer { get; private set; }   // выбранная компания
    }
}
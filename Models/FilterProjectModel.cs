using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.Models
{
    public class FilterProjectModel
    {
        public FilterProjectModel(List<Customer> customers, int? customer, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            customers.Insert(0, new Customer { Name = "Все", CustomerId = 0 });
            Customers = new SelectList(customers, "Id", "Name", customer);
            SelectedCompany = customer;
            SelectedName = name;
        }
        public SelectList Customers { get; private set; } // список компаний
        public int? SelectedCompany { get; private set; }   // выбранная компания
        public string SelectedName { get; private set; }    // введенное имя
    }
}
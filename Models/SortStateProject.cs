using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public enum SortStateProject
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию

        PriorityAsc, 
        PriorityDesc,   
        
        StartDateAsc, 
        StartDateDesc,

        FinishDateAsc,
        FinishDateDesc,

        CustomerAsc,
        CustomerDesc
    }
    
}
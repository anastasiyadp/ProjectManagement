using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.Models
{
    public class SortProjectModel
    {
        public SortStateProject NameSort { get; private set; } 
        public SortStateProject PrioritySort { get; private set; }    
        public SortStateProject StartDateSort { get; private set; }   
        public SortStateProject FinishDateSort { get; private set; }   
        public SortStateProject CustomerSort{ get; private set; }   
        public SortStateProject Current { get; private set; }     
       
        public SortProjectModel(SortStateProject sortOrder)
        {
            NameSort = sortOrder == SortStateProject.NameAsc ? SortStateProject.NameDesc : SortStateProject.NameAsc;
            PrioritySort = sortOrder == SortStateProject.PriorityAsc ? SortStateProject.PriorityDesc : SortStateProject.PriorityAsc;
            StartDateSort = sortOrder == SortStateProject.StartDateAsc ? SortStateProject.StartDateDesc : SortStateProject.StartDateAsc;
            FinishDateSort = sortOrder == SortStateProject.FinishDateAsc ? SortStateProject.FinishDateDesc : SortStateProject.FinishDateAsc;
            CustomerSort = sortOrder == SortStateProject.CustomerAsc ? SortStateProject.CustomerDesc : SortStateProject.CustomerAsc;
            Current = sortOrder;
        }
    }
}
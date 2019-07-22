﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProjectManagement.DAL;
using ProjectManagement.Models;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectContext db = new ProjectContext();

        public ActionResult AllProjects(int? customer, SortStateProject sortOrder = SortStateProject.NameAsc)
        {
            var projects = db.Projects.Include(c=>c.Customer);
            //фильтрация 
            if (customer!=null && customer != 0)
            {
                projects = projects.Where(p => p.CustomerId == customer);
            }

            //сортировка
            switch (sortOrder)
            {
                case SortStateProject.NameDesc:
                    projects = projects.OrderByDescending(s => s.Name);
                    break;
                case SortStateProject.PriorityAsc:
                    projects = projects.OrderBy(s => s.Priority);
                    break;
                case SortStateProject.PriorityDesc:
                    projects = projects.OrderByDescending(s => s.Priority);
                    break;
                case SortStateProject.StartDateAsc:
                    projects = projects.OrderBy(s => s.StartDate);
                    break;
                case SortStateProject.StartDateDesc:
                    projects = projects.OrderByDescending(s => s.StartDate);
                    break;
                case SortStateProject.FinishDateAsc:
                    projects = projects.OrderBy(s => s.FinishDate);
                    break;
                case SortStateProject.FinishDateDesc:
                    projects = projects.OrderByDescending(s => s.FinishDate);
                    break;
                case SortStateProject.CustomerAsc:
                    projects = projects.OrderBy(s => s.Customer.Name);
                    break;
                case SortStateProject.CustomerDesc:
                    projects = projects.OrderByDescending(s => s.Customer.Name);
                    break;
                default:
                    projects = projects.OrderBy(s => s.Name);
                    break;
            }


            //формирование модели представления
            AllProjectViewModel viewModel = new AllProjectViewModel
            {
                SortProjectModel = new SortProjectModel(sortOrder),
                FilterProjectModel = new FilterProjectModel(db.Customers.ToList(), customer),                
                Projects = projects
            };
            return View(viewModel);
        }

        public ActionResult ShowProject(int id)
        {
            Project project = db.Projects.Include(c => c.Customer).Where(c => c.ProjectId == id).FirstOrDefault();
            ViewBag.Employees = db.EmployeeProjects.Include(em => em.Employee).Include(im => im.Employee.Implementer).Where(empr => empr.Project.ProjectId == id).ToList();
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            ViewBag.Cus = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.Emp = new MultiSelectList(db.Employees, "EmployeeId", "Surname");
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("AllProjects");
        }

        public ActionResult EditProject(int Id)
        {
            Project project = db.Projects.Where(proj => proj.ProjectId == Id).FirstOrDefault();

            return View(project);
        }

        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AllProjects");
        }

        public ActionResult DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("AllProjects");
        }
    }
}
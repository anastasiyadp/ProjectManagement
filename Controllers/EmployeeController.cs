using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProjectManagement.DAL;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        public ActionResult AllEmployees()
        {
            return View(db.Employees.Include(c => c.Implementer).ToList());
        }

        public ActionResult ShowEmployee(int id)
        {
            Employee employee = db.Employees.Include(c => c.Implementer).Where(c => c.EmployeeId == id).FirstOrDefault();
           //ViewBag.Projects = db.EmployeeProjects.Include(em => em.Project).Where(empr => empr.Employee.EmployeeId == id).ToList();
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            ViewBag.Imp = new SelectList(db.Implementers, "ImplementerId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

        public ActionResult EditEmployee(int Id)
        {
            Employee employee = db.Employees.Where(empl =>empl.EmployeeId == Id).FirstOrDefault();

            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AllEmployees");
        }


        public ActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("AllEmployees");
        }
    }
}
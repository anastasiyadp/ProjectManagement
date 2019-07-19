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
    public class HomeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult OneProject(int id)
        {
            Project project = db.Projects.Include(c=>c.Customer).Include(c=>c.Implementer).Where(c=>c.ProjectId==id).FirstOrDefault();
            //var project = db.Projects.Include(c => c.Customer);
            ViewBag.Employees = db.EmployeeProjects.Include(em => em.Employee).Where(empr => empr.Project.ProjectId == id).ToList();
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
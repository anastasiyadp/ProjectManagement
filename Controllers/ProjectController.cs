using System;
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

        public ActionResult AllProjects(int? customer,int? priority, DateTime? start, DateTime? finish, SortStateProject sortOrder = SortStateProject.NameAsc)
        {
            var projects = db.Projects.Include(c=>c.Customer);

            //фильтрация по закзачику
            if (customer!=null && customer != 0)
            {
                projects = projects.Where(p => p.CustomerId == customer);
            }

            if (priority != null && priority != 0)
            {
                projects = projects.Where(p => p.Priority==priority);
            }


            //фильтрация по диапазону даты начала
            if (start!=null &&finish!=null)
            {
                projects = projects.Where(x => x.StartDate >= start
                    && x.StartDate <= finish);
            }

            //сортировка по полям
            switch (sortOrder)
            {
                case SortStateProject.NameDesc:
                    projects = projects.OrderByDescending(prj => prj.Name);
                    break;
                case SortStateProject.PriorityAsc:
                    projects = projects.OrderBy(prj => prj.Priority);
                    break;
                case SortStateProject.PriorityDesc:
                    projects = projects.OrderByDescending(prj => prj.Priority);
                    break;
                case SortStateProject.StartDateAsc:
                    projects = projects.OrderBy(prj => prj.StartDate);
                    break;
                case SortStateProject.StartDateDesc:
                    projects = projects.OrderByDescending(prj => prj.StartDate);
                    break;
                case SortStateProject.FinishDateAsc:
                    projects = projects.OrderBy(prj => prj.FinishDate);
                    break;
                case SortStateProject.FinishDateDesc:
                    projects = projects.OrderByDescending(prj => prj.FinishDate);
                    break;
                case SortStateProject.CustomerAsc:
                    projects = projects.OrderBy(prj => prj.Customer.Name);
                    break;
                case SortStateProject.CustomerDesc:
                    projects = projects.OrderByDescending(prj => prj.Customer.Name);
                    break;
                default:
                    projects = projects.OrderBy(prj => prj.Name);
                    break;
            }


            //формирование модели представления
            AllProjectViewModel viewModel = new AllProjectViewModel
            {
                SortProjectModel = new SortProjectModel(sortOrder),
                FilterProjectModel = new FilterProjectModel(db.Customers.ToList(), customer, start, finish, priority),                
                Projects = projects
            };
            return View(viewModel);
        }

        public ActionResult ShowProject(int id)
        {
            Project project = db.Projects.Include(prj => prj.Customer).Where(prj => prj.ProjectId == id).FirstOrDefault();
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
            ViewBag.Customer = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.Employee = new SelectList(db.Employees, "EmployeeId", "Surname");
            ViewBag.Role = new SelectList(Enum.GetValues(typeof(Role)).Cast<Role>().ToList());
            CreateProjectViewModel projectVM = new CreateProjectViewModel();
            return View(projectVM);
        }

        

        [HttpPost]
        public ActionResult CreateProject(FormCollection form)
        {
            string[] allID = form["Project.EmployeeProjects"].Split(char.Parse(","));
            string[] roles = form["Role"].Split(char.Parse(","));
                     
            Project project = new Project();
            project.Name = form["Project.Name"];
            project.Priority = Convert.ToInt32(form["Project.Priority"]);
            project.StartDate = Convert.ToDateTime(form["Project.StartDate"]);
            project.FinishDate = Convert.ToDateTime(form["Project.FinishDate"]);
            project.CustomerId = Convert.ToInt32(form["Project.CustomerId"]);

            for (int i = 0; i<allID.Length; i++) {
                int id = Convert.ToInt32(allID[i]);
                Role role = (Role)Enum.Parse(typeof(Role), roles[i]);
                Employee employee = db.Employees.Include(em => em.Implementer).Where(em => em.EmployeeId == id).FirstOrDefault();
                EmployeeProject empPrj = new EmployeeProject { Employee = employee, Project = project, Role = role };
                db.EmployeeProjects.Add(empPrj);
            }
            
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("AllProjects");
        }

        public ActionResult EditProject(int id)
        {
            CreateProjectViewModel projectVM = new CreateProjectViewModel();
            Project project = db.Projects.Include(c=>c.Customer).Where(proj => proj.ProjectId == id).FirstOrDefault();
            List<EmployeeProject> listEmployeePrj = db.EmployeeProjects.Include(em => em.Employee).Include(im => im.Employee.Implementer).Where(empr => empr.Project.ProjectId == id).ToList();
            List<Employee> emp = new List<Employee>();
            foreach (EmployeeProject emPrj in listEmployeePrj)
            {
                emp.Add(emPrj.Employee);
            }
            ViewBag.EmployeesPrj = emp;
            ViewBag.Employees = db.Employees.ToList();
            ViewBag.Role = new SelectList(Enum.GetValues(typeof(Role)).Cast<Role>().ToList());
            projectVM.Project = project;
            return View(projectVM);
        }

        [HttpPost]
        public ActionResult EditProject(FormCollection form, Project project, int[] selected)
        {
            string[] selectedEmployees = form["selectedEmployees"].Split(char.Parse(","));
            string[] rol = form["Role"].Split(char.Parse(","));

            Project prj = db.Projects.Find(project.ProjectId);
            prj.Name = project.Name;
            prj.Priority = project.Priority;
            prj.StartDate = project.StartDate;
            prj.FinishDate = project.FinishDate;
            prj.CustomerId = project.CustomerId;

            prj.EmployeeProjects.Clear();

            List<EmployeeProject> list = new List<EmployeeProject>();
            for (int i = 0; i < selectedEmployees.Length; i++)
            {
                int id = Convert.ToInt32(selectedEmployees[i]);
                Role role = (Role)Enum.Parse(typeof(Role), rol[id-1]);
                Employee employee = db.Employees.Include(em => em.Implementer).Where(em => em.EmployeeId == id).FirstOrDefault();
                EmployeeProject empPrj = new EmployeeProject { Employee = employee, Project = prj, Role = role };
                prj.EmployeeProjects.Add(empPrj);
                list.Add(empPrj);
            }
           // prj.EmployeeProjects = list;
            db.Entry(prj).State = EntityState.Modified;
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
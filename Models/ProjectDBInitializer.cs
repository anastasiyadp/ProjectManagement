using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectManagement.DAL;

namespace ProjectManagement.Models
{
    public class ProjectDBInitializer:DropCreateDatabaseAlways<ProjectContext>
    {

        protected override void Seed(ProjectContext context)
        {
            List<Implementer> implementers = new List<Implementer>
            {
                new Implementer { Name = "Sibers" },
                new Implementer { Name = "ITcommand" },
                new Implementer { Name = "Soft" },
                new Implementer { Name = "ITworld" }
            };

            implementers.ForEach(implementer => context.Implementers.Add(implementer));
            context.SaveChanges();

            List<Customer> customers = new List<Customer> {
                new Customer { Name = "Kari"}, 
                new Customer{ Name = "Сбербанк"},
                new Customer { Name = "Детский мир"}
            };

            customers.ForEach(customer => context.Customers.Add(customer));
            context.SaveChanges();

            List<Employee> employees = new List<Employee> {
                new Employee {
                    FirstName ="Анастасия",
                    Surname ="Мульторьян",
                    Patronymic ="Дмитриевна",
                    Email ="anastasiyadp@mail.ru",
                    ImplementerId = 1
                },
                new Employee {
                    FirstName ="Василий",
                    Surname ="Ситников",
                    Patronymic ="Генадьевич",
                    Email ="svg@yandex.ru",
                    ImplementerId = 3
                },
                new Employee {
                    FirstName ="Валерия",
                    Surname ="Грачова",
                    Patronymic ="Артемовна",
                    Email ="gva@gmail.com",
                    ImplementerId = 1
                },
                new Employee {
                    FirstName ="Александр",
                    Surname ="Меньшов",
                    Patronymic ="Валерьевич",
                    Email ="mav@mail.ru",
                    ImplementerId = 4
                },
                new Employee {
                    FirstName ="Злата",
                    Surname ="Лыкова",
                    Patronymic ="Степановна",
                    Email ="lzs@gmail.com",
                    ImplementerId = 2
                },
                 new Employee {
                    FirstName ="Артем",
                    Surname ="Буров",
                    Patronymic ="Вадимович",
                    Email ="bav@mail.ru",
                    ImplementerId = 2
                },
                new Employee {
                    FirstName ="Иван",
                    Surname ="Востриков",
                    Patronymic ="Игоревич",
                    Email ="vii@yandex.ru",
                    ImplementerId = 4
                },
            };

            employees.ForEach(employee => context.Employees.Add(employee));
            context.SaveChanges();

            List<Project> projects = new List<Project> {
                new Project {
                    Name ="Система контроля товаров",
                    StartDate = new DateTime(2019, 3, 2),
                    FinishDate = new DateTime(2019, 9, 2),
                    Priority = (int)Priority.Высокий,
                    CustomerId = 3
                },
                 new Project {
                    Name ="Система управления складом",
                    StartDate = new DateTime(2019, 7, 17),
                    FinishDate = new DateTime(2020, 2, 17),
                    Priority = (int)Priority.Средний,
                    CustomerId = 1
                },
                  new Project {
                    Name ="Мобильное приложение для клиентов",
                    StartDate = new DateTime(2019, 1, 15),
                    FinishDate = new DateTime(2019, 5, 15),
                    Priority = (int)Priority.Низкий,
                    CustomerId = 2
                }
            };

            projects.ForEach(project => context.Projects.Add(project));
            context.SaveChanges();

            List<EmployeeProject> employeeProjects = new List<EmployeeProject>
            {
                new EmployeeProject { EmployeeId = 1, ProjectId = 1, Role= Role.Руководитель },
                new EmployeeProject { EmployeeId = 2, ProjectId = 2, Role= Role.Руководитель},
                new EmployeeProject { EmployeeId = 3, ProjectId = 1, Role= Role.Исполнитель },
                new EmployeeProject { EmployeeId = 3, ProjectId = 2, Role= Role.Исполнитель },
                new EmployeeProject { EmployeeId = 5, ProjectId = 1, Role= Role.Исполнитель },
                new EmployeeProject { EmployeeId = 6, ProjectId = 3, Role= Role.Исполнитель },
                new EmployeeProject { EmployeeId = 2, ProjectId = 3, Role= Role.Исполнитель},
                new EmployeeProject { EmployeeId = 1, ProjectId = 2, Role= Role.Исполнитель },
                new EmployeeProject { EmployeeId = 3, ProjectId = 3, Role= Role.Руководитель },
                new EmployeeProject { EmployeeId = 6, ProjectId = 2, Role= Role.Исполнитель },
            };
            employeeProjects.ForEach(employeeProject => context.EmployeeProjects.Add(employeeProject));
            context.SaveChanges();


            base.Seed(context);
        }

    }
}
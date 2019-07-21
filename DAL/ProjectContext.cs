using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ProjectManagement.Models;

namespace ProjectManagement.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ProjectContext") {}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Implementer> Implementers { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    }
}
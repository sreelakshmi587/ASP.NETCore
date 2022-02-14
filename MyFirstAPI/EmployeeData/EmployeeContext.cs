using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.EmployeeData
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext>options):base(options)
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

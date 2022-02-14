using MyFirstAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.EmployeeData
{
    public interface IEmployeeData
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(Guid id);
        public Employee AddEmployee(Employee employee);
    }
}

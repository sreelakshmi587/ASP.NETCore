
using MyFirstAPI.EmployeeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Model
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            var employee = _employeeContext.Employees.Find(id);

            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}

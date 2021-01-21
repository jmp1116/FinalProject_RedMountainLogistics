using FinalProject_AscentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject_AscentApp
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployee(int id);
        public void UpdateEmployee(Employee employee);
        public void InsertEmployee(Employee employeeToInsert);
        //public IEnumerable<Employee> GetCategories();
        //public Employee AssignCategory();
        public void DeleteEmployee(Employee employee);
    }
}

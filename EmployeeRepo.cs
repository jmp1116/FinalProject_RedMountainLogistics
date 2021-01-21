using Dapper;
using FinalProject_AscentApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject_AscentApp
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IDbConnection _conn;
        public EmployeeRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _conn.Query<Employee>("SELECT * FROM employees;");
        }

        public Employee GetEmployee(int id)
        {
            return (Employee)_conn.QuerySingle<Employee>("SELECT * FROM employees WHERE EmployeeID = @id",
                 new { id = id });
        }

        public void InsertEmployee(Employee employeeToInsert)
        {
            _conn.Execute("INSERT INTO employees (FIRSTNAME, LASTNAME, EMAIL, PASSWORD, SALES) VALUES (@firstName, @lastName, @email, @password, @sales);",
                new { firstName = employeeToInsert.FirstName, lastName = employeeToInsert.LastName, email = employeeToInsert.Email, password = employeeToInsert.Password, sales = employeeToInsert.Sales });
        }

        public void UpdateEmployee(Employee employee)
        {
            _conn.Execute("UPDATE employees SET FirstName = @firstName, LastName = @lastName, Email = @email, Password = @password, Sales = @sales WHERE EmployeeID = @id",
                new { id = employee.EmployeeID, firstName = employee.FirstName, lastName = employee.LastName, email = employee.Email, password = employee.Password, sales = employee.Sales });
        
        }

        public void DeleteEmployee(Employee employee)
        {
            _conn.Execute("DELETE FROM EMPLOYEES WHERE EmployeeID = @id;", new { id = employee.EmployeeID });
        }
    }
}

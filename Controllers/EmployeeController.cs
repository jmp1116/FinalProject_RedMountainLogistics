using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject_AscentApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_AscentApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo repo;

        public EmployeeController(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var employees = repo.GetAllEmployees();

            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string empSearch)
        {
            ViewData["GetEmployeeDetails"] = empSearch;
            
            var empQuery = from x in repo.GetAllEmployees() select x;
            if (!String.IsNullOrEmpty(empSearch))
            {
                empQuery = empQuery.Where(s => !string.IsNullOrEmpty(s.LastName) && s.LastName.Contains(empSearch));
            }
            return View(empQuery);

        }

        public IActionResult ViewEmployee(int id)
        {
            var employee = repo.GetEmployee(id);
            return View(employee);
        }

        public IActionResult UpdateEmployee(int id)
        {
            var employee = repo.GetEmployee(id);

            if (employee == null)
            {
                return View("EmployeeNotFound");
            }

            return View(employee);
        }

        public IActionResult UpdateEmployeeToDatabase(Employee employee)
        {
            repo.UpdateEmployee(employee);

            return RedirectToAction("ViewEmployee", new { id = employee.EmployeeID });
        }

        public IActionResult InsertEmployee(Employee employeeToInsert)
        {
            repo.InsertEmployee(employeeToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult InsertEmployeeToDatabase(Employee employeeToInsert)
        {
            repo.InsertEmployee(employeeToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee (Employee employee)
        {
            repo.DeleteEmployee(employee);

            return RedirectToAction("Index");
        }

    }
}

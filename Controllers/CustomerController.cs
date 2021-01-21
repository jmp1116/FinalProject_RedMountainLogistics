using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject_AscentApp.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace FinalProject_AscentApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo repo;

        public CustomerController(ICustomerRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
           
           
                var customers = repo.GetAllCustomers();

                return View(customers);
            
           
        }

        [HttpGet]
        public async Task<IActionResult> Index(string custSearch)
        {
            
            ViewData["GetCustomerDetails"] = custSearch;

            var custQuery = from x in repo.GetAllCustomers() select x;
            if(!String.IsNullOrEmpty(custSearch))
            {
                custQuery = custQuery.Where(x => x.CompanyName.Contains(custSearch) || x.CustomerEmail.Contains(custSearch));
            }
            return View(custQuery);

        }

        public IActionResult ViewCustomer(int id)
        {
            var customer = repo.GetCustomer(id);
            return View(customer);
        }

        public IActionResult UpdateCustomer(int id)
        {
            var customer = repo.GetCustomer(id);

            if (customer == null)
            {
                return View("CustomerNotFound");
            }

            return View(customer);
        }

        public IActionResult UpdateCustomerToDatabase(Customer customer)
        {
            repo.UpdateCustomer(customer);

            return RedirectToAction("ViewCustomer", new { id = customer.CustomerID });
        }


        public IActionResult InsertCustomerToDatabase(Customer customerToInsert)
        {
            repo.InsertCustomer(customerToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult InsertCustomer(Customer customer)
        {
            repo.InsertCustomer(customer);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCustomer(Customer customer)
        {
            repo.DeleteCustomer(customer);

            return RedirectToAction("Index");
        }
    }
}

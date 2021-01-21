using FinalProject_AscentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject_AscentApp
{
    public interface ICustomerRepo
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomer(int id);
        public void UpdateCustomer(Customer customer);
        public void InsertCustomer(Customer customerToInsert);
        //public IEnumerable<CategoryModel> GetCategories();
        //public Customer BuildCustomer();
        public void DeleteCustomer(Customer customer);
    }
}

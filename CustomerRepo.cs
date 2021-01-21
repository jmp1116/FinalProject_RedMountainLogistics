using Dapper;
using FinalProject_AscentApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject_AscentApp
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly IDbConnection _conn;
        public CustomerRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        
        public void DeleteCustomer(Customer customer)
        {
            _conn.Execute("DELETE FROM CUSTOMERS WHERE CustomerID = @id;", new { id = customer.CustomerID });
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _conn.Query<Customer>("SELECT * FROM customers;");
        }

        public Customer GetCustomer(int id)
        {
            return (Customer)_conn.QuerySingle<Customer>("SELECT * FROM customers WHERE CustomerID = @id",
                 new { id = id });
        }

        public void InsertCustomer(Customer customerToInsert)
        {
            _conn.Execute("INSERT INTO customers (COMPANYNAME, CREDIT, MONEYSPENT, PHONENUMBER, CUSTOMEREMAIL) VALUES (@companyName, @credit, @moneySpent, @phoneNumber, @customerEmail);",
                new { companyName = customerToInsert.CompanyName, credit = customerToInsert.Credit, moneySpent = customerToInsert.MoneySpent, phoneNumber = customerToInsert.PhoneNumber, customerEmail = customerToInsert.CustomerEmail });
        }

        public void UpdateCustomer(Customer customer)
        {
            _conn.Execute("UPDATE customers SET CompanyName = @companyName, Credit = @credit, MoneySpent = @moneySpent, PhoneNumber = @phoneNumber, CustomerEmail = @customerEmail WHERE CustomerID = @id",
                new { companyName = customer.CompanyName, credit = customer.Credit, moneySpent = customer.MoneySpent, phoneNumber = customer.PhoneNumber, customerEmail = customer.CustomerEmail , id = customer.CustomerID});
        }

        //public Customer BuildCustomer(Customer customer)
        //{
        //    MySqlCommand sqlCmd = new MySqlCommand("CustomerAddOrEdit", (MySqlConnection)_conn);
        //    sqlCmd.CommandType = CommandType.StoredProcedure;
        //    sqlCmd.Parameters.AddWithValue("_customerid", Convert.ToInt32(customer.CustomerID));
        //    sqlCmd.Parameters.AddWithValue("_companyname", txtProduct.Text.Trim());

        //}
    }
}

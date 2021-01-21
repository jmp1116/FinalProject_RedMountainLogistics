using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject_AscentApp.Models
{
    public class Customer
    {

        public Customer()
        {

        }

        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int Credit { get; set; }
        public int MoneySpent { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerEmail { get; set; }

    }
}

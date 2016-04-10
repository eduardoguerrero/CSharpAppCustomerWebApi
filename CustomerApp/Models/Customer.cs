using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CustomerApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public string Telephone { get; set; }       
        public IList<Order> Orders { get; set; }       
    }
}
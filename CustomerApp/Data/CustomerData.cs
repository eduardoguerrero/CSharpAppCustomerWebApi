using System.Collections.Generic;
using CustomerApp.Models;
using System;
using System.Linq;
using System.Web;
namespace CustomerApp.Data
{
    public interface IDataCustomer
    {
        IEnumerable<Customer> CustumerList();
        IEnumerable<Customer> GetCustomerById(int id);    
        IList<Order> GetOrdersByCostumer(int id);
        Order GetOrdersDetailByCostumer(int customerId,int orderId);
    }

    public class DefaultIDataCustomer : IDataCustomer
    {

        /// <summary>
        /// Retrieve Customer by Id
        /// </summary>
        /// <param name="id">The Id of the customer</param>
        /// <returns>Details of Customer by Id</returns>
        public IEnumerable<Customer> GetCustomerById(int id)
        {
            var customer = from c in CustumerList() where c.CustomerID==id select c;
            return customer;           
        }      

        /// <summary>
        /// Retrieve order by Custumer
        /// </summary>
        /// <param name="id">The Id of the customer</param>
        /// <returns>List of orders</returns>
        public IList<Order> GetOrdersByCostumer(int id)
        {
            return CustumerList().FirstOrDefault(p => p.CustomerID == id).Orders;           
        }

        /// <summary>
        /// Retrieve order by Order Id
        /// </summary>
        /// <param name="customerId">The Id of the customer</param>
        /// <param name="orderId">The Id of the order</param>
        /// <returns>Order taking into account the order Id</returns>
        public Order GetOrdersDetailByCostumer(int customerId,int orderId)
        {         
            var orderDetail =  CustumerList().FirstOrDefault(
                p => p.CustomerID == customerId).Orders.FirstOrDefault(x=>x.OrderID==orderId);
            return orderDetail;
        }

        /// <summary>
        /// Get static data of the customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public IEnumerable<Customer> CustumerList()
        {
            Customer[] customersList = new Customer[]
            { 
                //CustomerID#1
                new Customer 
                {
                    CustomerID = 1, CompanyName = "CompanyA", Country = "MEXICO", Address = "Mexico DF",ContactName="ContactName1",Telephone="45345678",                 
                    Orders=  new Order[] 
                    { 
                        new Order {OrderID = 198, Description = "DescriptionOrderA", Date = "00/00/2016", Amount =20.5,Quantity=30 }, 
                        new Order {OrderID = 199, Description = "DescriptionOrderB", Date = "00/00/2016", Amount =30.7,Quantity=70 },  
                        new Order {OrderID = 200, Description = "DescriptionOrderC", Date = "00/00/2017", Amount =30.9,Quantity=9}, 
                    }
                },
                //CustomerID#2
                new Customer 
                {
                    CustomerID = 2, CompanyName = "CompanyB", Country = "EL SALVADOR", Address = "San Salvador",ContactName="ContactName2",Telephone="45345458",                 
                    Orders=  new Order[] 
                    { 
                        new Order {OrderID = 201, Description = "DescriptionOrderE", Date = "10/02/2015", Amount =20.0,Quantity=33 }, 
                        new Order {OrderID = 202, Description = "DescriptionOrderF", Date = "04/02/2015", Amount =30.3,Quantity=75 },  
                        new Order {OrderID = 203, Description = "DescriptionOrderG", Date = "01/02/2015", Amount =30.6,Quantity=99}, 
                    }
                },
                //CustomerID#3
                new Customer 
                {
                    CustomerID = 3, CompanyName = "CompanyC", Country = "PANAMA", Address = "Panama",ContactName="ContactName3",Telephone="45235678",                 
                    Orders=  new Order[] 
                    { 
                        new Order {OrderID = 204, Description = "DescriptionOrderH", Date = "00/00/2014", Amount =2.5,Quantity=90 }
                    }
                },            
                //CustomerID#4
                new Customer 
                {
                    CustomerID = 4, CompanyName = "CompanyD", Country = "GUATEMALA", Address = "Ciudad de Guatemala",ContactName="ContactName4",Telephone="45345458",                 
                    Orders=  new Order[] 
                    { 
                        new Order {OrderID = 205, Description = "DescriptionOrderI", Date = "13/02/2015", Amount =20.1,Quantity=53 }, 
                        new Order {OrderID = 206, Description = "DescriptionOrderJ", Date = "14/05/2015", Amount =30.2,Quantity=75 },  
                        new Order {OrderID = 207, Description = "DescriptionOrderK", Date = "01/12/2015", Amount =30.3,Quantity=19},
                        new Order {OrderID = 208, Description = "DescriptionOrderL", Date = "10/03/2015", Amount =20.4,Quantity=33 }, 
                        new Order {OrderID = 209, Description = "DescriptionOrderM", Date = "04/02/2015", Amount =30.5,Quantity=75 },  
                        new Order {OrderID = 210, Description = "DescriptionOrderN", Date = "01/02/2015", Amount =30.7,Quantity=89},
                    }
                },
                //CustomerID#5
                new Customer 
                {
                    CustomerID = 5, CompanyName = "CompanyD", Country = "BRAZIL", Address = "Sao Paolo",ContactName="ContactName5",Telephone="45233478",                 
                    Orders=  new Order[] 
                    { 
                        new Order {OrderID = 211, Description = "DescriptionOrderO", Date = "00/00/2012", Amount =2.0,Quantity=100 }
                    }
                }
            };
            return customersList;
        }

    }
}
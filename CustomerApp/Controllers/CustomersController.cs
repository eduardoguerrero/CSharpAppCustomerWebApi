using CustomerApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using CustomerApp.Data;

namespace CustomerApp.Controllers
{
    public class CustomersController : ApiController
    {
        public CustomersController()
            : this(new DefaultIDataCustomer())
        { }

        /// <summary>
        /// Inject the dependecy,see the file CustomerData
        /// </summary>
        private readonly IDataCustomer _dataCustomer;
       
        public CustomersController(IDataCustomer dataCustomer)
        {
            _dataCustomer = dataCustomer;
        }            

        // GET api/customers
        ///<summary>
        ///Retrieve a summary of customers.
        ///</summary>      
        public IEnumerable<Customer> Get()
        {
            return _dataCustomer.CustumerList();
        }

        // GET api/customers/{customerid}
        /// <summary>
        /// Retrieve individual full customer details.
        /// </summary>
        /// <param name="customerid">The Id of the customer.</param>  
        public HttpResponseMessage GetCustomer(int customerid)
        {
            var customer = _dataCustomer.GetCustomerById(customerid);          
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);            
            return this.Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        // GET api/customers/{customerid}/orders
        /// <summary>
        /// Retrieve customer's order.
        /// </summary>
        /// <param name="customerid">The Id of the customer.</param>       
        public HttpResponseMessage GetOrdersByCostumer(int customerid)
        {
            var order = _dataCustomer.GetOrdersByCostumer(customerid);
            if (order == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return this.Request.CreateResponse(HttpStatusCode.OK, order);
        }

        // GET api/customers/{customerid}/orders/{orderid}
        /// <summary>
        /// Retrieve the detail of the order taking into account the customer.
        /// </summary>
        /// <param name="customerid">The Id of the customer</param>
        /// <param name="orderid">The Id of the order</param>     
        public HttpResponseMessage GetOrdersDetailByCostumer(int customerid,int orderid)
        {
            var order = _dataCustomer.GetOrdersDetailByCostumer(customerid,orderid);
            if (order == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return this.Request.CreateResponse(HttpStatusCode.OK, order);
        }

        /// <summary>
        /// Delete a customer(soft delete)
        /// </summary>
        /// <param name="customerid">The id of the customer that you want delete</param>
        /// <returns></returns>       
        public HttpRequestMessage DeleteCustomer(int customerid)
        {
            throw new HttpResponseException(HttpStatusCode.NotImplemented);
        }

    }
}

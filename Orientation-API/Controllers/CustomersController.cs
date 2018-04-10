using Orientation_API.Models;
using Orientation_API.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orientation_API.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        [HttpPut, Route("{id}")]
        public HttpResponseMessage Edit(int id, CustomerDto customer)
        {
            var dtoToCustomer = new CustomerModel
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Zip = customer.Zip,
                Phone = customer.Phone,
                CustomerId = id
            };

            var customerRepository = new CustomerRepository();
            
            try
            {
                var updateCustomer = customerRepository.EditCustomer(dtoToCustomer);
            }
            catch (SqlException)
            {

                throw;
            }
           

            return Request.CreateResponse(HttpStatusCode.OK, "Customer has been updated.");
        }
    }

    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int Phone { get; set; }
    }
}

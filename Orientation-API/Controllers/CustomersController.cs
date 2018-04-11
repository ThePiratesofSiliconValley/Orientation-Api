using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Orientation_API.Models;
using Orientation_API.Services;

namespace Orientation_API.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetCustomers(CustomerModel customer)

        {
            var customers = new CustomerRepository();
            var customerList = customers.Get();

            return Request.CreateResponse(HttpStatusCode.Accepted, customerList);
           
        }
        

    }
}

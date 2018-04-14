using Orientation_API.Models;
using Orientation_API.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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
                PostalCode = customer.PostalCode,
                Phone = customer.Phone,
                CustomerId = id
            };

            var customerModifier = new CustomerModifier();
            var editCustomer = customerModifier.EditCustomer(dtoToCustomer);

            switch (editCustomer)
            {
                case Models.StatusCode.NotFound:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"{id} is invalid. Please provide a valid customer ID.");
                case Models.StatusCode.Success:
                    return Request.CreateResponse(HttpStatusCode.OK, "Customer has been updated.");
                case Models.StatusCode.Unsuccessful:
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong, please try again later.");
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong, please try again later.");
            }
        }


        [HttpPatch, Route("{id}/inactive")]
        public HttpResponseMessage MakeInactive(int id)
        {
            var customerRepository = new CustomerRepository();
            var getSingleCustomer = customerRepository.GetSingle(id);

            if (!getSingleCustomer)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not find customer");
            }
            else if (customerRepository.IsInactive(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Cannot make customer inactive at this time. Try again later.");
        }

        [Route(""), HttpPost]
        public HttpResponseMessage CreateCustomer(CustomerModel customer)
        {
            var repository = new CustomerRepository();
            var result = repository.CreateCustomer(customer);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Customer has been created");
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                "The customer didn't save, try again");
        }
       

    }


}

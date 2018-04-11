﻿using Orientation_API.Models;
using Orientation_API.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        [HttpPut, Route("")]
        public HttpResponseMessage MakeInactive(int customerId)
        {
            var customerRepository = new CustomerRepository();
            var getSingleCustomer = customerRepository.GetSingle(customerId);


        }
    }


}

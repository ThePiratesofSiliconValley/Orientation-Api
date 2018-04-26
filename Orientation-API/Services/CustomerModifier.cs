using Orientation_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Orientation_API.Services
{
    public class CustomerModifier
    {
        public StatusCode EditCustomer(CustomerModel customer)
        {
            var customerRepository = new ComputerRepository();
            bool checkCustomer;

            try
            {
                checkCustomer = customerRepository.GetSingle(customer.CustomerId);
            }
            catch (SqlException)
            {
                return StatusCode.Unsuccessful;
            }
            catch (Exception)
            {
                return StatusCode.NotFound;
            }


            var updateCustomer = customerRepository.EditCustomer(customer);

            return updateCustomer
                ? StatusCode.Success
                : StatusCode.Unsuccessful;
        }
    }
}
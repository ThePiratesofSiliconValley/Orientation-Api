﻿using Dapper;
using Orientation_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Orientation_API.Services
{
    public class CustomerRepository
    {
        public bool EditCustomer(CustomerModel customer)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var editCustomer = db.Execute(@"UPDATE Customer
                                                               SET FirstName = @firstName
                                                                  ,LastName = @lastName
                                                                  ,Address = @address
                                                                  ,City = @city
                                                                  ,State = @state
                                                                  ,PostalCode = @postalCode
                                                                  ,Phone = @phone
                                                             WHERE CustomerId = @customerId", customer);

                return editCustomer == 1;
            }
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }
    }
}
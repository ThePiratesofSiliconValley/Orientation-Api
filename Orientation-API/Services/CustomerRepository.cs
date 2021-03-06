﻿using Dapper;
using Orientation_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


namespace Orientation_API.Services
{
    public class ComputerRepository
    {
        public IEnumerable<CustomerModel> Get()
        {
            using (var db =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var listOfCustomers = db.Query<CustomerModel>(@"Select * from Customer
                                                                WHERE IsInactive != 1 or IsInactive is NULL");
                return listOfCustomers;

            }
        }

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
                                                                  ,PostalCode = @PostalCode
                                                                  ,Phone = @phone
                                                             WHERE CustomerId = @customerId", customer);

                return editCustomer == 1;
            }
        }

        internal bool GetSingle(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var getCustomer = db.QueryFirst("select * from customer where customerId = @id", new { id });

                return getCustomer != null;
            }
        }

        public bool IsActive(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var makeCustomerActive = db.Execute(@"UPDATE Customer
                                                        SET IsInactive = 0
                                                        WHERE CustomerId = @id", new {id});

                return makeCustomerActive == 1;
            }
        }

        public bool IsInactive(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var makeCustomerInactive = db.Execute(@"UPDATE Customer
                                                        SET IsInactive = 1
                                                        WHERE CustomerId = @id", new {id});

                return makeCustomerInactive == 1;
            }
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }

        public bool CreateCustomer(CustomerModel customer)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var createCustomer = db.Execute(@"INSERT INTO [dbo].[Customer]
                                               ([FirstName]
                                               ,[LastName]
                                               ,[Address]
                                               ,[City]
                                               ,[State]
                                               ,[PostalCode]
                                               ,[Phone])
                                         VALUES
                                               (@FirstName
                                               ,@LastName
                                               ,@Address
                                               ,@City
                                               ,@State
                                               ,@PostalCode
                                               ,@Phone)", customer);
                return createCustomer == 1;

            }
        }
    }


}

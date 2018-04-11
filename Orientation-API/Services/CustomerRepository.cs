using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Orientation_API.Models;

namespace Orientation_API.Services
{
    public class CustomerRepository
    {
        public IEnumerable<CustomerModel> Get()
        {
            using (var db =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var listOfCustomers = db.Query<CustomerModel>(@"Select * from Customer");
                return listOfCustomers;

            }


        }
    }


}

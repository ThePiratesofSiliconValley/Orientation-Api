using Dapper;
using Orientation_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Orientation_API.Services
{
    public class ProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using (var db = createConnection())
            {
                db.Open();

                var products = db.Query<Product>("select * from products");

                return products;
            }
        }

        public SqlConnection createConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }
    }

}
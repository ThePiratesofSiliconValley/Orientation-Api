using Dapper;
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

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
    }
}
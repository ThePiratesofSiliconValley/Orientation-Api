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

        public bool Create(Product product)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();
                var numberCreated = db.Execute(@"INSERT INTO [dbo].[Products]
                                               ([ProductName]
                                               ,[ProductDescription]
                                               ,[ProductPrice]
                                               ,[Quantity]
                                               ,[CustomerId])
                                         VALUES
                                               (@ProductName
                                               ,@ProductDescription
                                               ,@ProductPrice
                                               ,@Quantity
                                               ,@CustomerId)", product);

                return numberCreated == 1;
            }
        }

        public bool Remove(int productId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();
                var productRemoved = db.Execute(@"DELETE FROM Products
                                                  WHERE ProductId = @productId", new {productId});

                return productRemoved > 0;
            }
        }

        public Product GetSingleProduct(int productId)
        {
            using (var db = createConnection())
            {
                db.Open();

                var singleProduct = db.QueryFirstOrDefault<Product>(@"SELECT * FROM Products WHERE ProductId = @productId", new {productId});

                return singleProduct;
            }
        }
    }

}
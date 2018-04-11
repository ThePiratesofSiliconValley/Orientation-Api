using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Orientation_API.Models;

namespace Orientation_API.Services
{
    public class OrderRepository
    {
        public bool CreateOrder(CreateOrderDto createOrderDto)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var orderCreated = db.Execute("@INSERT into Orders (CustomerId, SalesRepId) VALUES (@CustomerId, @SalesRepId)", createOrderDto);

                return orderCreated == 1;
            }
        }

        public bool AddProductToOrder(PlaceOrderDto placeOrderDto)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var orderPlaced = db.Execute(@"INSERT into OrderLine (OrderId, ProductId, Quantity)
                Values (@OrderId, @ProductId, @Quantity)", placeOrderDto);

                return orderPlaced == 1;
            }
        }
    }

    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public int SalesRepId { get; set; }
    }
}
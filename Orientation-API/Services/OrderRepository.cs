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
            using (var db = CreateConnection())
            {
                db.Open();

                var orderCreated = db.Execute(@"INSERT into Orders (CustomerId, SalesRepId) VALUES (@CustomerId, @SalesRepId)", createOrderDto);

                return orderCreated == 1;
            }
        }

        public bool AddProductToOrder(PlaceOrderDto placeOrderDto)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var orderPlaced = db.Execute(@"INSERT into OrderLine (OrderId, ProductId, Quantity)
                Values (@OrderId, @ProductId, @Quantity)", placeOrderDto);

                return orderPlaced == 1;
            }
        }
        public IEnumerable<Order> GetOutstandingOrders()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var outstandingOrders = db.Query<Order>("select * from Orders where PaymentTypeId is null");

                return outstandingOrders;
            }
        }

        public Product GetProductQuantity(int productId)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var product = db.QueryFirst<Product>(@"SELECT * from Products WHERE ProductId = @productId", new { productId });

                return product;
            }
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }

        public bool MarkAsPaid(CompleteOrderDto completeOrderDto)
        {
            using (var db = CreateConnection())
            {
                db.Open();
                var query = @"UPDATE [dbo].[Orders]
                                               SET 
                                                  [PaymentTypeId] = @PaymentTypeId
     
                                             WHERE OrderId = @OrderId";
                var queryVariables = new {completeOrderDto.PaymentTypeId, completeOrderDto.OrderId};
                var markAsPaid = db.Execute(query, queryVariables);
                return markAsPaid == 1;
            }
        }
    }
}
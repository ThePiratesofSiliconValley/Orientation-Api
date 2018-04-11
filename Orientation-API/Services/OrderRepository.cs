﻿using System;
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
        //public bool CreateOrder();

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

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }
    }

}
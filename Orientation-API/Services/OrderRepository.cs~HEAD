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
        //public bool CreateOrder();

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
}
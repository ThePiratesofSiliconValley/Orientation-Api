using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class PlaceOrderDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int SalesRepId { get; set; }
        public int CustomerId { get; set; }
        public int? OrderId { get; set; }
    }
}
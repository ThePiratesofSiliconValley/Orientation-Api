using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int TotalProducts { get; set; }
        public double TotalPrice { get; set; }
        public int PaymentTypeId { get; set; }
        public int SalesRepId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public int SalesRepId { get; set; }
    }
}
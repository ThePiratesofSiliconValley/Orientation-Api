using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class ComputerDto
    {
        public string ComputerManufacturer { get; set; }
        public string ComputerMake { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
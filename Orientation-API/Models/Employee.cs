using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? SeparationDate { get; set; }
        public int ComputerId { get; set; }
    }
}
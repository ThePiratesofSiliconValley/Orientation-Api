using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeModel> Employees { get; internal set; }
    }
}
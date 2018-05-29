using System;

namespace Orientation_API.Models
{
    public class EmployeeEditDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime SeparationDate { get; set; }
        public int ComputerId { get; set; }
    }
}
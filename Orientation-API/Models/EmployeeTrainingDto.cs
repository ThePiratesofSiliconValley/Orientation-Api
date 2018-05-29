using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class EmployeeTrainingDto
    {
        public EmployeeTrainingDto()
        {
            TrainingName = new List<string>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string ComputerMake { get; set; }
        public List<string> TrainingName { get; set; }
        public int EmployeeTrainingId { get; set; }
        public int EmployeeId { get; set; }
        public int TrainingId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? SeparataionDate { get; set; }
        public int ComputerId { get; set; }
        public int DepartmentId { get; set; }
    }
}
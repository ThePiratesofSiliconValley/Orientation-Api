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
        public int EmployeeId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class EmployeeTrainingDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Computer { get; set; }
        public List<string> Trainings { get; set; }
        public int EmployeeId { get; set; }

        
    }
}
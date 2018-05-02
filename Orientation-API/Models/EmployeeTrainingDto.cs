using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class EmployeeTrainingDto
    {
        public int EmployeeTrainingId { get; set; }
        public int EmployeeId { get; set; }
        public int TrainingId { get; set; }
    }
}
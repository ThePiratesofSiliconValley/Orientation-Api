using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Orientation_API.Models
{
    public class TrainingProgramDto
    {
        public string TrainingName { get; set; }
        public DateTime StartDayDate { get; set; }
        public DateTime EndDayDate { get; set; }
        public int MaxAttendees { get; set; }
    }
}
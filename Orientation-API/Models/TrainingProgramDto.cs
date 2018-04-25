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
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public int MaxAttendees { get; set; }
    }
}
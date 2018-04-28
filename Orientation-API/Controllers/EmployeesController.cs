using Orientation_API.Models;
using Orientation_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orientation_API.Controllers
{
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage DisplayEmployees(EmployeeDto employee)
        {
            var employeeInfo = new EmployeeRepository();
            var displayEmployees = employeeInfo.Get();


            return Request.CreateResponse(HttpStatusCode.OK, displayEmployees);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage AddEmployee(EmployeeDto employee)
        {
            
        }
    }
}

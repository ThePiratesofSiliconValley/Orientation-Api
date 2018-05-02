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

        [HttpGet, Route("{id}")]
        public HttpResponseMessage SingleEmployee(int id)
        {
            var employeeInfo = new EmployeeTrainingRepository();
            var displayEmployee = employeeInfo.GetSingle(id);
            return Request.CreateResponse(HttpStatusCode.OK, displayEmployee);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage AddEmployee(NewEmployeeDto employee)
        {
            var employeeInfo = new EmployeeRepository();
            var createNewEmployee = employeeInfo.AddNewEmployee(employee);

            return Request.CreateResponse(HttpStatusCode.Created, employeeInfo);
        }

        [HttpGet, Route("{trainingId}")]
        public HttpResponseMessage GetByTraining(int trainingId)
        {
            var employeeRepository = new EmployeeRepository();
            var employeesByTraining = employeeRepository.GetEmployeesByTraining(trainingId);

            return Request.CreateResponse(HttpStatusCode.OK, employeesByTraining);
        }
    }
}

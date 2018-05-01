using Orientation_API.Models;
using Orientation_API.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        [HttpPut, Route("{id}")]
        public HttpResponseMessage EditEmployee(int id, EmployeeEditDto employee)
        {
            var repo = new EmployeeRepository();
            Employee getEmployee;

            try
            {
                getEmployee = repo.GetSingleEmployee(id);
            }
            catch (SqlException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong updating this employee, please try again later.");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "That user does not exist.");
            }

            var updatedEmployee = repo.ConvertEmployee(employee, id);
            var updateEmployee = repo.UpdateEmployee(updatedEmployee);

            return updateEmployee
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong updating this employee, please try again later.");
        }

        [HttpPost, Route("{id}/trainings/{trainingId}")]
        public HttpResponseMessage AddTraining(int id, int trainingId)
        {
            var repo = new EmployeeRepository();
            var addTraining = repo.AddTrainingToEmployee(id, trainingId);

            return addTraining
                ? Request.CreateResponse(HttpStatusCode.Created, "A training has been added to this employee!")
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "There was an error creating this training, please try again later.");
        }

        [HttpDelete, Route("{id}/training")]
        public HttpResponseMessage DeleteTrainings(int id)
        {
            var repo = new EmployeeRepository();
            Employee getEmployee;

            try
            {
                getEmployee = repo.GetSingleEmployee(id);
            }
            catch (SqlException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong updating this employee, please try again later.");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "That user does not exist.");
            }

            var deleteTraining = repo.DeleteTraining(id);

            return deleteTraining
                ? Request.CreateResponse(HttpStatusCode.OK, "The training has been deleted.")
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "There was an error deleting this training, please try again later.");
        }
        
    }

}

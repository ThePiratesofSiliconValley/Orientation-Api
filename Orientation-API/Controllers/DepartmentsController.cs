using Orientation_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Orientation_API.Models;
using System.Web.Http;

namespace Orientation_API.Controllers
{
    [RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetAllDepartments()
        {
            var repo = new DepartmentsRepository();
            var departmentList = repo.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, departmentList);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage CreateDepartment(DepartmentsDto department)
        {
            var repo = new DepartmentsRepository();
            var newDepartment = repo.CreateDepartment(department);
        }
    }
}
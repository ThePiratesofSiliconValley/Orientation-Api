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
    [RoutePrefix("api/computers")]
    public class ComputersController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            var repo = new ComputerRespository();
            var results = repo.GetAllComputers();
            var resultsDto = repo.ComputerReturn(results);

            return Request.CreateResponse(HttpStatusCode.OK, resultsDto);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Create(ComputerDto computer)
        {
            var repo = new ComputerRespository();
            var dtoToComputer = repo.ConvertComputer(computer);
            var result = repo.AddNewComputer(dtoToComputer);

            if (!result)
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong with trying to create this employee. Please try again later.");

            return Request.CreateResponse(HttpStatusCode.Created, "Computer has been created!");
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var repo = new ComputerRespository();
            bool employeeCheck;

            try
            {
                employeeCheck = repo.GetSingleComputer(id);
            }
            catch (SqlException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong, please try again later.");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"It appears that the computer ID {id} does not exist, or has an employee associated with it.");
            }

            var deleteComputer = repo.Delete(id);

            if (!deleteComputer)
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong, please try again later.");


                return Request.CreateResponse(HttpStatusCode.OK, "the computer has been deleted.");
        }
    }

    public class ComputerDto
    {
        public string ComputerManufacturer { get; set; }
        public string ComputerMake { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}

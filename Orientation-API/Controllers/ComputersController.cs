using Orientation_API.Services;
using System;
using System.Collections.Generic;
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

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}

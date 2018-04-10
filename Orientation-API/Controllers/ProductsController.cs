using Orientation_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orientation_API.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            var productRepository = new ProductRepository();
            var allProducts = productRepository.GetAllProducts();

            return Request.CreateResponse(HttpStatusCode.OK, allProducts);
        }
    }
}

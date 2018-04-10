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

        [Route(""), HttpPost]
        public HttpResponseMessage CreateProduct(Product product)
        {
            var productRepository = new ProductRepository();
            var result = productRepository.Create(product);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create product, try again later");
        }
    }
}

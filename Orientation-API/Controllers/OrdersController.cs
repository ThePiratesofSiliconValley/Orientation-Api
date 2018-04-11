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
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        [Route("placeorder"), HttpPost]
        public HttpResponseMessage PlaceOrder(PlaceOrderDto placeOrderDto)
        {
            var orderRepo = new OrderRepository();

            if (placeOrderDto.OrderId == null)
            {
                throw new NotImplementedException();
            }
            
            var addToOrderResult = orderRepo.AddProductToOrder(placeOrderDto);

            if (addToOrderResult)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Sorry about your luck.");
        }
    }
}

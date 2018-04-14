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
        [Route("createorder"), HttpPost]
        public HttpResponseMessage CreateNewOrder(CreateOrderDto createOrderDto)
        {
            var orderRepo = new OrderRepository();
            var createNewOrder = orderRepo.CreateOrder(createOrderDto);

            if(createOrderDto.CustomerId < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "There is no account yet.");
            }

            if (createNewOrder)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "There was a problem creating the account.");
        }

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

        [Route("outstanding"), HttpGet]
        public HttpResponseMessage GetOutstanding()
        {
            var orderRepository = new OrderRepository();
            var outstandingOrders = orderRepository.GetOutstandingOrders();

            if (outstandingOrders != null)
                return Request.CreateResponse(HttpStatusCode.OK, outstandingOrders);

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Sorry, something went wrong. Please try again later.");
        }
    }
}

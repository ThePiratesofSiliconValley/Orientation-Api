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
        public HttpResponseMessage PlaceOrder()
        {
            throw new NotImplementedException();
        }
    }
}

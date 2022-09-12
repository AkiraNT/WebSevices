using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SanpiNetwork.Controllers
{
    public class CheckVersionController : ApiController
    {
        [HttpGet]
        [Route("api/v1/Version/Check")]
        public HttpResponseMessage CheckVersion()
        {
            object result = new
            {
                Status= 1
            };
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
            return response;
        }
    }
}

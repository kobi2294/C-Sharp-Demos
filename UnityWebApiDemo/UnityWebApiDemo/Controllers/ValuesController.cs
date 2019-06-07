using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UnityWebApiDemo.Services;

namespace UnityWebApiDemo.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private INumbersService _service;

        public ValuesController(INumbersService service)
        {
            _service = service;
        }

        [HttpGet]
        [ResponseType(typeof(List<int>))]
        [Route("random")]
        public IHttpActionResult GetRandomNumbers()
        {
            var res = _service.GenerateRandomNumbers();
            return Ok(res);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Unity;
using UnityWebApiDemo.Models;
using UnityWebApiDemo.Services;

namespace UnityWebApiDemo.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private INumbersService _service;
        private Transaction _transaction;

        public ValuesController(INumbersService service, Transaction transaction, IUnityContainer container)
        {
            _service = service;
            _transaction = transaction;
        }

        [HttpGet]
        [ResponseType(typeof(List<int>))]
        [Route("random")]
        public IHttpActionResult GetRandomNumbers()
        {
            var res = _service.GenerateRandomNumbers();
            _transaction.Actions.Add("Generating Random Numbers");
            return Ok(res);
        }

    }
}

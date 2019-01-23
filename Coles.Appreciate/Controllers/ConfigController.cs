using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Coles.Appreciate.Domain;

namespace Coles.Appreciate.Controllers
{
    
    [EnableCors(origins: "*", headers:"*", methods: "*")]
    [RoutePrefix("api/v1/config")]
    public class ConfigController : ApiController
    {
        // GET api/<controller>
        [Route("big")]
        [HttpGet]
        public IHttpActionResult Get()
        {


            //string[] vals = new string[] { "value1", "value2" };
            Coles.Appreciate.Domain.Response[] vals = new Coles.Appreciate.Domain.Response[] { new Coles.Appreciate.Domain.Response("hh","Jj"), new Coles.Appreciate.Domain.Response("dd", "ff") };
            
            return Json(vals);
            

            
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Coles.Appreciate.Domain;

namespace Coles.Appreciate.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/person")]
    public class PersonController : ApiController
    {
        readonly Coles.Appreciate.Domain.Person[] db = new Coles.Appreciate.Domain.Person[] {
            new Coles.Appreciate.Domain.Person("mvmanley", "Mark Manley")
            , new Coles.Appreciate.Domain.Person("jsmith", "Jon smith")
            , new Coles.Appreciate.Domain.Person("cbutler", "chris butler")
            , new Coles.Appreciate.Domain.Person("mpound", "mary pound")
            , new Coles.Appreciate.Domain.Person("geverett", "Grettle everett")
            , new Coles.Appreciate.Domain.Person("msmyth", "Mike smyth")


        };


        // GET api/<controller>
        [Route("findUser")]
        [HttpGet]
        public IHttpActionResult Get(string search)
        {

            string[] parts = search.Split(',');
            PersonSearch ps = null;
            List<PersonSearch> resp = new List<PersonSearch>();

            foreach(string part in parts)
            {
                ps = new PersonSearch(part.Trim());
                ps.Results = db.Where(c => c.UserId.StartsWith(ps.SearchTerm)).ToArray();
                if (ps.Results.Length == 0)
                {
                    ps.Results = db.Where(c => c.UserName.Contains(ps.SearchTerm)).ToArray();
                }

                resp.Add(ps);
            }

            //string[] vals = new string[] { "value1", "value2" };
            //Coles.Appreciate.Domain.Response[] vals = new Coles.Appreciate.Domain.Response[] { new Coles.Appreciate.Domain.Response("hh", "Jj"), new Coles.Appreciate.Domain.Response("dd", "ff") };
            //db.Where(c => c.UserName.Contains(search)).ToArray();
            return Json(resp);
        }

    }
}
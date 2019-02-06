using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Coles.Appreciate.Domain.Models;
using Coles.Appreciate.Models;

namespace Coles.Appreciate.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResponsesController : ApiController
    {
        private ColesAppreciateDataContext db = new ColesAppreciateDataContext();

        // GET: api/Responses
        public IQueryable<Response> GetResponses()
        {
            return db.Responses;
        }

        // GET: api/Responses/5
        [ResponseType(typeof(Response))]
        public async Task<IHttpActionResult> GetResponse(int id)
        {
            Response response = await db.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // PUT: api/Responses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResponse(int id, Response response)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != response.ResponseId)
            {
                return BadRequest();
            }

            db.Entry(response).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Responses
        [ResponseType(typeof(Response))]
        public async Task<IHttpActionResult> PostResponse(Response response)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Responses.Add(response);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = response.ResponseId }, response);
        }

        // DELETE: api/Responses/5
        [ResponseType(typeof(Response))]
        public async Task<IHttpActionResult> DeleteResponse(int id)
        {
            Response response = await db.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            db.Responses.Remove(response);
            await db.SaveChangesAsync();

            return Ok(response);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResponseExists(int id)
        {
            return db.Responses.Count(e => e.ResponseId == id) > 0;
        }
    }
}
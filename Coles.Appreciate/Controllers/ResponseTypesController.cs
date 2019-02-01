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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Coles.Appreciate.Domain.Models;
using Coles.Appreciate.Models;

namespace Coles.Appreciate.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResponseTypesController : ApiController
    {
        private ColesAppreciateContext db = new ColesAppreciateContext();

        // GET: api/ResponseTypes
        public IQueryable<ResponseType> GetResponseTypes()
        {
            return db.ResponseTypes;
        }

        // GET: api/ResponseTypes/5
        [ResponseType(typeof(ResponseType))]
        public async Task<IHttpActionResult> GetResponseType(int id)
        {
            ResponseType responseType = await db.ResponseTypes.FindAsync(id);
            if (responseType == null)
            {
                return NotFound();
            }

            return Ok(responseType);
        }

        // PUT: api/ResponseTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResponseType(int id, ResponseType responseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != responseType.ResponseId)
            {
                return BadRequest();
            }

            db.Entry(responseType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponseTypeExists(id))
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

        // POST: api/ResponseTypes
        [ResponseType(typeof(ResponseType))]
        public async Task<IHttpActionResult> PostResponseType(ResponseType responseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResponseTypes.Add(responseType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = responseType.ResponseId }, responseType);
        }

        // DELETE: api/ResponseTypes/5
        [ResponseType(typeof(ResponseType))]
        public async Task<IHttpActionResult> DeleteResponseType(int id)
        {
            ResponseType responseType = await db.ResponseTypes.FindAsync(id);
            if (responseType == null)
            {
                return NotFound();
            }

            db.ResponseTypes.Remove(responseType);
            await db.SaveChangesAsync();

            return Ok(responseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResponseTypeExists(int id)
        {
            return db.ResponseTypes.Count(e => e.ResponseId == id) > 0;
        }
    }
}
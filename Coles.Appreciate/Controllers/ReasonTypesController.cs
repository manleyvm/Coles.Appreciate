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
    public class ReasonTypesController : ApiController
    {
        private ColesAppreciateContext db = new ColesAppreciateContext();

        // GET: api/ReasonTypes
        public IQueryable<ReasonType> GetReasonTypes()
        {
            return db.ReasonTypes;
        }

        // GET: api/ReasonTypes/5
        [ResponseType(typeof(ReasonType))]
        public async Task<IHttpActionResult> GetReasonType(int id)
        {
            ReasonType reasonType = await db.ReasonTypes.FindAsync(id);
            if (reasonType == null)
            {
                return NotFound();
            }

            return Ok(reasonType);
        }

        // PUT: api/ReasonTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReasonType(int id, ReasonType reasonType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reasonType.ReasonId)
            {
                return BadRequest();
            }

            db.Entry(reasonType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReasonTypeExists(id))
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

        // POST: api/ReasonTypes
        [ResponseType(typeof(ReasonType))]
        public async Task<IHttpActionResult> PostReasonType(ReasonType reasonType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReasonTypes.Add(reasonType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reasonType.ReasonId }, reasonType);
        }

        // DELETE: api/ReasonTypes/5
        [ResponseType(typeof(ReasonType))]
        public async Task<IHttpActionResult> DeleteReasonType(int id)
        {
            ReasonType reasonType = await db.ReasonTypes.FindAsync(id);
            if (reasonType == null)
            {
                return NotFound();
            }

            db.ReasonTypes.Remove(reasonType);
            await db.SaveChangesAsync();

            return Ok(reasonType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReasonTypeExists(int id)
        {
            return db.ReasonTypes.Count(e => e.ReasonId == id) > 0;
        }
    }
}
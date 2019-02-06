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
    public class ReasonsController : ApiController
    {
        private ColesAppreciateDataContext db = new ColesAppreciateDataContext();

        // GET: api/Reasons
        public IQueryable<Reason> GetReasons()
        {
            return db.Reasons;
        }

        // GET: api/Reasons/5
        [ResponseType(typeof(Reason))]
        public async Task<IHttpActionResult> GetReason(int id)
        {
            Reason reason = await db.Reasons.FindAsync(id);
            if (reason == null)
            {
                return NotFound();
            }

            return Ok(reason);
        }

        // PUT: api/Reasons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReason(int id, Reason reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reason.ReasonId)
            {
                return BadRequest();
            }

            db.Entry(reason).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReasonExists(id))
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

        // POST: api/Reasons
        [ResponseType(typeof(Reason))]
        public async Task<IHttpActionResult> PostReason(Reason reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reasons.Add(reason);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reason.ReasonId }, reason);
        }

        // DELETE: api/Reasons/5
        [ResponseType(typeof(Reason))]
        public async Task<IHttpActionResult> DeleteReason(int id)
        {
            Reason reason = await db.Reasons.FindAsync(id);
            if (reason == null)
            {
                return NotFound();
            }

            db.Reasons.Remove(reason);
            await db.SaveChangesAsync();

            return Ok(reason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReasonExists(int id)
        {
            return db.Reasons.Count(e => e.ReasonId == id) > 0;
        }
    }
}
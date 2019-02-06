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
    public class AppreciationReasonsController : ApiController
    {
        private ColesAppreciateDataContext db = new ColesAppreciateDataContext();

        // GET: api/AppreciationReasons
        public IQueryable<AppreciationReason> GetAppreciationReasons()
        {
            return db.AppreciationReasons;
        }

        // GET: api/AppreciationReasons/5
        [ResponseType(typeof(AppreciationReason))]
        public async Task<IHttpActionResult> GetAppreciationReason(int id)
        {
            AppreciationReason appreciationReason = await db.AppreciationReasons.FindAsync(id);
            if (appreciationReason == null)
            {
                return NotFound();
            }

            return Ok(appreciationReason);
        }

        // PUT: api/AppreciationReasons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppreciationReason(int id, AppreciationReason appreciationReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appreciationReason.AppreciationReasonId)
            {
                return BadRequest();
            }

            db.Entry(appreciationReason).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppreciationReasonExists(id))
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

        // POST: api/AppreciationReasons
        [ResponseType(typeof(AppreciationReason))]
        public async Task<IHttpActionResult> PostAppreciationReason(AppreciationReason appreciationReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppreciationReasons.Add(appreciationReason);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appreciationReason.AppreciationReasonId }, appreciationReason);
        }

        // DELETE: api/AppreciationReasons/5
        [ResponseType(typeof(AppreciationReason))]
        public async Task<IHttpActionResult> DeleteAppreciationReason(int id)
        {
            AppreciationReason appreciationReason = await db.AppreciationReasons.FindAsync(id);
            if (appreciationReason == null)
            {
                return NotFound();
            }

            db.AppreciationReasons.Remove(appreciationReason);
            await db.SaveChangesAsync();

            return Ok(appreciationReason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppreciationReasonExists(int id)
        {
            return db.AppreciationReasons.Count(e => e.AppreciationReasonId == id) > 0;
        }
    }
}
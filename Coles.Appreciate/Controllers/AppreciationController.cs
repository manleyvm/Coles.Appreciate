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
    public class AppreciationController : ApiController
    {
        private ColesAppreciateDataContext db = new ColesAppreciateDataContext();

        // GET: api/Appreciation
        public IQueryable<Appreciation> GetAppreciations()
        {
            return db.Appreciations;
        }

        // GET: api/Appreciation/5
        [ResponseType(typeof(Appreciation))]
        public async Task<IHttpActionResult> GetAppreciation(int id)
        {
            Appreciation appreciation = await db.Appreciations.FindAsync(id);
            if (appreciation == null)
            {
                return NotFound();
            }

            return Ok(appreciation);
        }

        // PUT: api/Appreciation/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppreciation(int id, Appreciation appreciation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appreciation.AppreciationId)
            {
                return BadRequest();
            }

            db.Entry(appreciation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppreciationExists(id))
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

        // POST: api/Appreciation
        [ResponseType(typeof(Appreciation))]
        public async Task<IHttpActionResult> PostAppreciation(Appreciation appreciation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appreciations.Add(appreciation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appreciation.AppreciationId }, appreciation);
        }

        // DELETE: api/Appreciation/5
        [ResponseType(typeof(Appreciation))]
        public async Task<IHttpActionResult> DeleteAppreciation(int id)
        {
            Appreciation appreciation = await db.Appreciations.FindAsync(id);
            if (appreciation == null)
            {
                return NotFound();
            }

            db.Appreciations.Remove(appreciation);
            await db.SaveChangesAsync();

            return Ok(appreciation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppreciationExists(int id)
        {
            return db.Appreciations.Count(e => e.AppreciationId == id) > 0;
        }
    }
}
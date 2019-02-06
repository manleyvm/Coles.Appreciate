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
    public class AppreciationTargetsController : ApiController
    {
        private ColesAppreciateDataContext db = new ColesAppreciateDataContext();

        // GET: api/AppreciationTargets
        public IQueryable<AppreciationTarget> GetAppreciationTargets()
        {
            return db.AppreciationTargets;
        }

        // GET: api/AppreciationTargets/5
        [ResponseType(typeof(AppreciationTarget))]
        public async Task<IHttpActionResult> GetAppreciationTarget(int id)
        {
            AppreciationTarget appreciationTarget = await db.AppreciationTargets.FindAsync(id);
            if (appreciationTarget == null)
            {
                return NotFound();
            }

            return Ok(appreciationTarget);
        }

        // PUT: api/AppreciationTargets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppreciationTarget(int id, AppreciationTarget appreciationTarget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appreciationTarget.AppreciationTargetId)
            {
                return BadRequest();
            }

            db.Entry(appreciationTarget).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppreciationTargetExists(id))
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

        // POST: api/AppreciationTargets
        [ResponseType(typeof(AppreciationTarget))]
        public async Task<IHttpActionResult> PostAppreciationTarget(AppreciationTarget appreciationTarget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppreciationTargets.Add(appreciationTarget);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appreciationTarget.AppreciationTargetId }, appreciationTarget);
        }

        // DELETE: api/AppreciationTargets/5
        [ResponseType(typeof(AppreciationTarget))]
        public async Task<IHttpActionResult> DeleteAppreciationTarget(int id)
        {
            AppreciationTarget appreciationTarget = await db.AppreciationTargets.FindAsync(id);
            if (appreciationTarget == null)
            {
                return NotFound();
            }

            db.AppreciationTargets.Remove(appreciationTarget);
            await db.SaveChangesAsync();

            return Ok(appreciationTarget);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppreciationTargetExists(int id)
        {
            return db.AppreciationTargets.Count(e => e.AppreciationTargetId == id) > 0;
        }
    }
}
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
    public class AppreciationAgreesController : ApiController
    {
        private ColesAppreciateDataContext db = new ColesAppreciateDataContext();

        // GET: api/AppreciationAgrees
        public IQueryable<AppreciationAgree> GetAppreciationAgrees()
        {
            return db.AppreciationAgrees;
        }

        // GET: api/AppreciationAgrees/5
        [ResponseType(typeof(AppreciationAgree))]
        public async Task<IHttpActionResult> GetAppreciationAgree(int id)
        {
            AppreciationAgree appreciationAgree = await db.AppreciationAgrees.FindAsync(id);
            if (appreciationAgree == null)
            {
                return NotFound();
            }

            return Ok(appreciationAgree);
        }

        // PUT: api/AppreciationAgrees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppreciationAgree(int id, AppreciationAgree appreciationAgree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appreciationAgree.AppreciationAgreeId)
            {
                return BadRequest();
            }

            db.Entry(appreciationAgree).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppreciationAgreeExists(id))
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

        // POST: api/AppreciationAgrees
        [ResponseType(typeof(AppreciationAgree))]
        public async Task<IHttpActionResult> PostAppreciationAgree(AppreciationAgree appreciationAgree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppreciationAgrees.Add(appreciationAgree);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appreciationAgree.AppreciationAgreeId }, appreciationAgree);
        }

        // DELETE: api/AppreciationAgrees/5
        [ResponseType(typeof(AppreciationAgree))]
        public async Task<IHttpActionResult> DeleteAppreciationAgree(int id)
        {
            AppreciationAgree appreciationAgree = await db.AppreciationAgrees.FindAsync(id);
            if (appreciationAgree == null)
            {
                return NotFound();
            }

            db.AppreciationAgrees.Remove(appreciationAgree);
            await db.SaveChangesAsync();

            return Ok(appreciationAgree);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppreciationAgreeExists(int id)
        {
            return db.AppreciationAgrees.Count(e => e.AppreciationAgreeId == id) > 0;
        }
    }
}
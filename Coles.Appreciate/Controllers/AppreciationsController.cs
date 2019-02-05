using System;
using System.Collections;
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
    public class AppreciationsController : ApiController
    {
        private ColesAppreciateContext db = new ColesAppreciateContext();

        // GET: api/Appreciations
        public IQueryable<Appreciation> GetAppreciations()
        {
            return db.Appreciations;
        }

        // GET: api/Appreciations/5
        [ResponseType(typeof(Appreciation))]
        public async Task<IHttpActionResult> GetAppreciation(int id)
        {

            Appreciation appreciation = await db.Appreciations.FindAsync(id);
            if (appreciation == null)
            {
                return NotFound();
            }

            //apprs = db.AppreciationReasons.Where(x => x.AppreciationId == id );
            //appreciation.AppreciationReasons = db.AppreciationReasons.Where(x => x.AppreciationId == id).ToList();

            return Ok(appreciation);
        }

        // PUT: api/Appreciations/5
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

        // POST: api/Appreciations
        [ResponseType(typeof(Appreciation))]
        public async Task<IHttpActionResult> PostAppreciation(Appreciation appreciation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (appreciation.AppreciationId == 0)
            {
                appreciation.AppreciationId =  getNextAppreciationId();
                
                appreciation.AppreciationReasons.All(c => { c.AppreciationId = appreciation.AppreciationId; return true; });

            } 

            

            db.Appreciations.Add(appreciation);
            
            await db.SaveChangesAsync();

            

            return CreatedAtRoute("DefaultApi", new { id = appreciation.AppreciationId }, appreciation);
        }

        // DELETE: api/Appreciations/5
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

        private int getNextAppreciationId()
        {
            //var rawSql = db.Database.SqlQuery<int>("select next value for dbo.AppreciateId_Seq;");
            //var task = rawSql.FirstOrDefault<int>();

            //rawSql.


            //int seq = db.Database.SqlQuery<int>("select next value for dbo.AppreciateId_Seq").FirstOrDefault();
            //int nextVal = task.Result;

            //return task;
            //NEXT VALUE FOR dbo.AppreciateId_Seq

            //var rawQuery = db.Database.SqlQuery<int>("SELECT next value for AppreciateId_Seq;");
            //int nextVal = rawQuery.FirstOrDefault<int>();
            //int nextVal = task.Result;
            
            return db.Database.SqlQuery<int>("SELECT next value for AppreciateId_Seq;").FirstOrDefault<int>();

        }
    }
}
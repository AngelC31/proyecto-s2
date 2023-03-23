using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Description;
using ApiGhost;

namespace ApiGhost.Controllers
{
   
    public class Monitoreo1Controller : ApiController
    {
        private GhostGymApiEntities db = new GhostGymApiEntities();

        // GET: api/Monitoreo1
        public IQueryable<Monitoreo1> GetMonitoreo1()
        {
            return db.Monitoreo1;
        }

        // GET: api/Monitoreo1/5
        [ResponseType(typeof(Monitoreo1))]
        public IHttpActionResult GetMonitoreo1(int id)
        {
            Monitoreo1 monitoreo1 = db.Monitoreo1.Find(id);
            if (monitoreo1 == null)
            {
                return NotFound();
            }

            return Ok(monitoreo1);
        }

        // PUT: api/Monitoreo1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonitoreo1(int id, Monitoreo1 monitoreo1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monitoreo1.RowNumber)
            {
                return BadRequest();
            }

            db.Entry(monitoreo1).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Monitoreo1Exists(id))
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

        // POST: api/Monitoreo1
        [ResponseType(typeof(Monitoreo1))]
        public IHttpActionResult PostMonitoreo1(Monitoreo1 monitoreo1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monitoreo1.Add(monitoreo1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monitoreo1.RowNumber }, monitoreo1);
        }

        // DELETE: api/Monitoreo1/5
        [ResponseType(typeof(Monitoreo1))]
        public IHttpActionResult DeleteMonitoreo1(int id)
        {
            Monitoreo1 monitoreo1 = db.Monitoreo1.Find(id);
            if (monitoreo1 == null)
            {
                return NotFound();
            }

            db.Monitoreo1.Remove(monitoreo1);
            db.SaveChanges();

            return Ok(monitoreo1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Monitoreo1Exists(int id)
        {
            return db.Monitoreo1.Count(e => e.RowNumber == id) > 0;
        }
    }
}
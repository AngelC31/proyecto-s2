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
    
    public class SuscripcionsController : ApiController
    {
        private GhostGymApiEntities db = new GhostGymApiEntities();

        // GET: api/Suscripcions
        public IQueryable<Suscripcion> GetSuscripcion()
        {
            return db.Suscripcion;
        }

        // GET: api/Suscripcions/5
        [ResponseType(typeof(Suscripcion))]
        public IHttpActionResult GetSuscripcion(int id)
        {
            Suscripcion suscripcion = db.Suscripcion.Find(id);
            if (suscripcion == null)
            {
                return NotFound();
            }

            return Ok(suscripcion);
        }

        // PUT: api/Suscripcions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuscripcion(int id, Suscripcion suscripcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suscripcion.Id_Suscripcion)
            {
                return BadRequest();
            }

            db.Entry(suscripcion).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuscripcionExists(id))
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

        // POST: api/Suscripcions
        [ResponseType(typeof(Suscripcion))]
        public IHttpActionResult PostSuscripcion(Suscripcion suscripcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suscripcion.Add(suscripcion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suscripcion.Id_Suscripcion }, suscripcion);
        }

        // DELETE: api/Suscripcions/5
        [ResponseType(typeof(Suscripcion))]
        public IHttpActionResult DeleteSuscripcion(int id)
        {
            Suscripcion suscripcion = db.Suscripcion.Find(id);
            if (suscripcion == null)
            {
                return NotFound();
            }

            db.Suscripcion.Remove(suscripcion);
            db.SaveChanges();

            return Ok(suscripcion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuscripcionExists(int id)
        {
            return db.Suscripcion.Count(e => e.Id_Suscripcion == id) > 0;
        }
    }
}
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
    
    public class DetEjerciciosController : ApiController
    {
        private GhostGymApiEntities db = new GhostGymApiEntities();

        // GET: api/DetEjercicios
        public IQueryable<DetEjercicio> GetDetEjercicio()
        {
            return db.DetEjercicio;
        }

        // GET: api/DetEjercicios/5
        [ResponseType(typeof(DetEjercicio))]
        public IHttpActionResult GetDetEjercicio(int id)
        {
            DetEjercicio detEjercicio = db.DetEjercicio.Find(id);
            if (detEjercicio == null)
            {
                return NotFound();
            }

            return Ok(detEjercicio);
        }

        // PUT: api/DetEjercicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetEjercicio(int id, DetEjercicio detEjercicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detEjercicio.Id_Detalle)
            {
                return BadRequest();
            }

            db.Entry(detEjercicio).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetEjercicioExists(id))
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

        // POST: api/DetEjercicios
        [ResponseType(typeof(DetEjercicio))]
        public IHttpActionResult PostDetEjercicio(DetEjercicio detEjercicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetEjercicio.Add(detEjercicio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detEjercicio.Id_Detalle }, detEjercicio);
        }

        // DELETE: api/DetEjercicios/5
        [ResponseType(typeof(DetEjercicio))]
        public IHttpActionResult DeleteDetEjercicio(int id)
        {
            DetEjercicio detEjercicio = db.DetEjercicio.Find(id);
            if (detEjercicio == null)
            {
                return NotFound();
            }

            db.DetEjercicio.Remove(detEjercicio);
            db.SaveChanges();

            return Ok(detEjercicio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetEjercicioExists(int id)
        {
            return db.DetEjercicio.Count(e => e.Id_Detalle == id) > 0;
        }
    }
}
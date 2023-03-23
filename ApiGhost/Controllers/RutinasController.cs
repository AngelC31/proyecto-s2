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
    
    public class RutinasController : ApiController
    {
        private GhostGymApiEntities db = new GhostGymApiEntities();

        // GET: api/Rutinas
        public IQueryable<Rutinas> GetRutinas()
        {
            return db.Rutinas;
        }

        // GET: api/Rutinas/5
        [ResponseType(typeof(Rutinas))]
        public IHttpActionResult GetRutinas(int id)
        {
            Rutinas rutinas = db.Rutinas.Find(id);
            if (rutinas == null)
            {
                return NotFound();
            }

            return Ok(rutinas);
        }

        // PUT: api/Rutinas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRutinas(int id, Rutinas rutinas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rutinas.Id_Rutina)
            {
                return BadRequest();
            }

            db.Entry(rutinas).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutinasExists(id))
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

        // POST: api/Rutinas
        [ResponseType(typeof(Rutinas))]
        public IHttpActionResult PostRutinas(Rutinas rutinas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rutinas.Add(rutinas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rutinas.Id_Rutina }, rutinas);
        }

        // DELETE: api/Rutinas/5
        [ResponseType(typeof(Rutinas))]
        public IHttpActionResult DeleteRutinas(int id)
        {
            Rutinas rutinas = db.Rutinas.Find(id);
            if (rutinas == null)
            {
                return NotFound();
            }

            db.Rutinas.Remove(rutinas);
            db.SaveChanges();

            return Ok(rutinas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutinasExists(int id)
        {
            return db.Rutinas.Count(e => e.Id_Rutina == id) > 0;
        }
    }
}
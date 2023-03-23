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
    
    public class HorariosController : ApiController
    {
        private GhostGymApiEntities db = new GhostGymApiEntities();

        // GET: api/Horarios
        public IQueryable<Horario> GetHorario()
        {
            return db.Horario;
        }

        // GET: api/Horarios/5
        [ResponseType(typeof(Horario))]
        public IHttpActionResult GetHorario(int id)
        {
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return NotFound();
            }

            return Ok(horario);
        }

        // PUT: api/Horarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHorario(int id, Horario horario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horario.Id_Horario)
            {
                return BadRequest();
            }

            db.Entry(horario).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(id))
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

        // POST: api/Horarios
        [ResponseType(typeof(Horario))]
        public IHttpActionResult PostHorario(Horario horario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horario.Add(horario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = horario.Id_Horario }, horario);
        }

        // DELETE: api/Horarios/5
        [ResponseType(typeof(Horario))]
        public IHttpActionResult DeleteHorario(int id)
        {
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return NotFound();
            }

            db.Horario.Remove(horario);
            db.SaveChanges();

            return Ok(horario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HorarioExists(int id)
        {
            return db.Horario.Count(e => e.Id_Horario == id) > 0;
        }
    }
}
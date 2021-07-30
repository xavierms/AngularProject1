using EMPLOYEEMAINTENANCE_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMPLOYEEMAINTENANCE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        IAsignacionesCon _asignacionesCon;
        public AsignacionesController(IAsignacionesCon asignacionesCon)
        {
            _asignacionesCon = asignacionesCon;
        }
        // GET: api/<AsignacionesController>
        [HttpGet]
        public IEnumerable<Asignaciones> Get()
        {
            return _asignacionesCon.Lists();
        }

        // GET api/<AsignacionesController>/5
        [HttpGet("{id}")]
        public ActionResult <Asignaciones> GetId(int id)
        {
            var asignacion = _asignacionesCon.BuscarPorID(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            return _asignacionesCon.BuscarPorID(id);
        }

        // POST api/<AsignacionesController>
        [HttpPost]
        public ActionResult Post([FromBody] Asignaciones model)
        {
            if (model != null)
            {
                _asignacionesCon.Añadir(model);
            }

            return CreatedAtAction("GetId", new { id = model.Asignacionid }, model);
        }

        // PUT api/<AsignacionesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Asignaciones model)
        {
            if (id != model.Asignacionid)
            {
                return BadRequest();
            }
            if (model != null)
            {
                _asignacionesCon.Actualizar(model, id);
            }
            return NoContent();
        }

        // DELETE api/<AsignacionesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var asignacion = _asignacionesCon.BuscarPorID(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            _asignacionesCon.Borrar(id);
            return NoContent();
        }
    }
}

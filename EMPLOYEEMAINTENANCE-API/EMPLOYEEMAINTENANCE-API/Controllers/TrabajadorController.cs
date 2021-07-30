using EMPLOYEEMAINTENANCE_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EMPLOYEEMAINTENANCE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        ITrabajadorCon _trabajadorCon;
        public TrabajadorController(ITrabajadorCon trabajadorCon)
        {
            _trabajadorCon = trabajadorCon;
        }
        // GET: api/<TrabajadorController>
        [HttpGet]
        public IEnumerable<Trabajador> Get()
        {


            return _trabajadorCon.Lists();

        }

        // GET api/<TrabajadorController>/5
        [HttpGet("{id}")]
        public ActionResult<Trabajador> GetId(int id)
        {
            var trabajador = _trabajadorCon.BuscarPorID(id);
            if (trabajador == null)
            {

                return NotFound();
            }
            return _trabajadorCon.BuscarPorID(id);
        }

        // POST api/<TrabajadorController>
        [HttpPost]
        public ActionResult Post([FromBody] Trabajador model)
        {
            if (model != null)
            {

                _trabajadorCon.Añadir(model);
            }

            return CreatedAtAction("GetId", new { id = model.Trabajadorid }, model);


        }

        // PUT api/<TrabajadorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Trabajador model)
        {
            if (id != model.Trabajadorid)
            {
                return BadRequest();
            }
            if (model != null)
            {
                _trabajadorCon.Actualizar(model, id);

            }
            return NoContent();
        }

        // DELETE api/<TrabajadorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var trabajador = _trabajadorCon.BuscarPorID(id);
            if (trabajador == null)
            {

                return NotFound();
            }


            _trabajadorCon.Borrar(id);
            return NoContent();

        }
    }
}

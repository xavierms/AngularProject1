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
    public class EdificiosController : ControllerBase
    {
        IEdificiosCon _edificiosCon;
        public EdificiosController(IEdificiosCon edificiosCon)
        {
            _edificiosCon = edificiosCon;
        }
        // GET: api/<EdificiosController>
        [HttpGet]
        public IEnumerable<Edificios> Get()
        {
            return _edificiosCon.Lists();
        }

        // GET api/<EdificiosController>/5
        [HttpGet("{id}")]
        public ActionResult <Edificios> GetId(int id)
        {
            var edificios = _edificiosCon.BuscarPorID(id);
            if (edificios == null)
            {
                return NotFound();
            }
            return _edificiosCon.BuscarPorID(id);
        }

        // POST api/<EdificiosController>
        [HttpPost]
        public ActionResult Post([FromBody] Edificios model)
        {

            if (model !=null)
            {
                _edificiosCon.Añadir(model);
            }

            return CreatedAtAction("GetId", new { id = model.EdificiosId }, model);
        }

        // PUT api/<EdificiosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Edificios model)
        {
            if (id != model.EdificiosId)
            {
                return BadRequest();
            }
            if (model != null)
            {
                _edificiosCon.Actualizar(model, id);
            }
            return NoContent();
        }

        // DELETE api/<EdificiosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var edificios = _edificiosCon.BuscarPorID(id);
            if (edificios == null)
            {
                return NotFound();
            }
            _edificiosCon.Borrar(id);
            return NoContent();
        }
    }
}

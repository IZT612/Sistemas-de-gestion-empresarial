using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        IPersonaUC _personaUC;

        public PersonaController(IPersonaUC personaUC)
        {
            _personaUC = personaUC;
        }

        // GET: api/<PersonaController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;
            List<Persona> personas = new List<Persona>();
            
            try
            {

                personas = _personaUC.getListaPersonas();

                if (personas.Count() == 0)
                {

                    resultado = NoContent();

                } else
                {

                    resultado = Ok(personas);

                }

            } catch
            {

                resultado = BadRequest();

            }

            return resultado;
        }

        // GET: api/<PersonaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult resultado;    

            try
            {
                var persona = _personaUC.getDetallesPersona(id);

                if (persona == null)
                {
                    resultado = NotFound();
                }
                else
                {
                    resultado = Ok(persona);
                }
            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }


        // POST: api/<PersonaController>
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            IActionResult resultado;

            try
            {
                if (persona == null)
                    return BadRequest();

                int filasAfectadas = _personaUC.crearPersona(persona);

                if (filasAfectadas != 0)
                    resultado = Ok(persona);
                else
                    resultado = NoContent();

            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }


        // PUT: api/<PersonaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Persona persona)
        {
            IActionResult resultado;

            try
            {
                if (persona == null || persona.id != id)
                    return BadRequest();

                int filasAfectadas = _personaUC.actualizarPersona(id, persona);

                if (filasAfectadas != 0)
                    resultado = Ok(persona);
                else
                    resultado = NoContent();
            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }


        // DELETE: api/<PersonaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult resultado;

            try
            {
                int filasAfectadas = _personaUC.eliminarPersona(id);

                if (filasAfectadas != 0)
                    resultado = Ok();
                else
                    resultado = NoContent();
            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }

    }
}

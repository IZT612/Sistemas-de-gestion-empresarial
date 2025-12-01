using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Entities;

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoUC _departamentoUC;

        public DepartamentoController(IDepartamentoUC departamentoUC)
        {
            _departamentoUC = departamentoUC;
        }

        // GET: api/<DepartamentoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;
            List<Departamento> departamentos = new List<Departamento>();

            try
            {
                departamentos = _departamentoUC.getDepartamentos();

                if (departamentos.Count == 0)
                    resultado = NoContent();
                else
                    resultado = Ok(departamentos);
            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }

        // GET: api/<DepartamentoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult resultado;

            try
            {
                var departamento = _departamentoUC.getDetalleDepartamento(id);

                if (departamento == null)
                    resultado = NotFound();
                else
                    resultado = Ok(departamento);
            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }

        // POST: api/<DepartamentoController>
        [HttpPost]
        public IActionResult Post([FromBody] Departamento departamento)
        {
            IActionResult resultado;

            try
            {
                if (departamento == null)
                    return BadRequest();

                int filasAfectadas = _departamentoUC.crearDepartamento(departamento);

                if (filasAfectadas != 0)
                    resultado = Ok(departamento);
                else
                    resultado = NoContent();
            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }

        // PUT: api/<DepartamentoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departamento departamento)
        {
            IActionResult resultado;

            try
            {
                if (departamento == null || departamento.id != id)
                    return BadRequest();

                int filasAfectadas = _departamentoUC.actualizarDepartamento(id, departamento);

                if (filasAfectadas != 0)
                    resultado = Ok(departamento);
                else
                    resultado = NoContent();
            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }

        // DELETE: api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult resultado;

            try
            {
                int filasAfectadas = _departamentoUC.eliminarDepartamento(id);

                if (filasAfectadas == -1)
                {
                
                    resultado = Conflict("No se puede eliminar el departamento porque tiene personas asignadas.");
                }
                else if (filasAfectadas != 0)
                {
                    resultado = Ok();
                }
                else
                {
                    resultado = NoContent();
                }
            }
            catch
            {
                resultado = BadRequest();
            }

            return resultado;
        }
    }
}

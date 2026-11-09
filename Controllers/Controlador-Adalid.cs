using Microsoft.AspNetCore.Mvc;
using BEPrueba.Data;
using BEPrueba.Dominio;

namespace BEPrueba.Controllers
{
    [ApiController]
    [Route("api/adalid/personas")]
    public class ControladorAdalidController : ControllerBase
    {
        private readonly DBContext _context;

        public ControladorAdalidController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPersona(
            [FromBody] Persona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre) ||
                string.IsNullOrWhiteSpace(persona.Ci) ||
                string.IsNullOrWhiteSpace(persona.Estado))
            {
                return BadRequest(new
                {
                    mensaje = "Todos los campos son obligatorios"
                });
            }

            _context.Personas.Add(persona);

            await _context.SaveChangesAsync();

            return StatusCode(201, new
            {
                mensaje = "Persona registrada correctamente por Adalid",
                datos = persona
            });
        }
    }
}
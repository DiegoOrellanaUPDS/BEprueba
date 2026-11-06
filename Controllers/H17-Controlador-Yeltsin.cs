using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BEPrueba.Data;
using BEPrueba.Dominio;

namespace BEPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class H17_Controlador_Yeltsin : ControllerBase
    {
        private readonly DBContext _context;

        public H17_Controlador_Yeltsin(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersona()
        {
            
            var personas = await _context.Personas.ToListAsync();
            return Ok(personas);
        }
        
        [HttpPost]
        public async Task<IActionResult> CrearPersona([FromBody] Persona nuevaPersona)
        {
            if (nuevaPersona == null)
            {
                return BadRequest("Los datos de la persona son inválidos.");
            }

            _context.Personas.Add(nuevaPersona);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersona), new { id = nuevaPersona.Id }, nuevaPersona);
        }
    }
}

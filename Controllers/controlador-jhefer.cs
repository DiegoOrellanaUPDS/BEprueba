using Microsoft.AspNetCore.Mvc;
using BEPrueba.Dominio;
using BEPrueba.Data; 
using Microsoft.EntityFrameworkCore;

namespace BEPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DBContext _context; 

        public PersonaController(DBContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Persona registrada correctamente",
                datos = persona
            });
        }
    }
}
using BEPrueba.Data;
using BEPrueba.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controlador_marco : ControllerBase
    {
       private readonly DBContext _context;

        public Controlador_marco(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            if (persona == null)
                return BadRequest();

            _context.Personas.Add(persona);
            _context.SaveChanges();

            return Ok(persona);
        }
    }
}


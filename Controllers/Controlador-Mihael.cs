using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BEPrueba.Data;
using BEPrueba.Dominio;

namespace BEPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controlador_Mihael : ControllerBase
    {
        private readonly DBContext _context;

        public Controlador_Mihael(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Persona> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();

            return Created();
        }
    }
}

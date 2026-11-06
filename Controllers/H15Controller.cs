using BEPrueba.Data;
using BEPrueba.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace BEPrueba.Controllers;

[ApiController]
[Route("api/h15")]
public class H15Controller : ControllerBase
{
    private readonly DBContext _context;

    public H15Controller(DBContext context)
    {
        _context = context;
    }

    [HttpPost("personas")]
    public async Task<IActionResult> CrearPersona(
        [FromBody] CrearPersonaRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nombre) ||
            string.IsNullOrWhiteSpace(request.Ci) ||
            string.IsNullOrWhiteSpace(request.Estado))
        {
            return BadRequest("Todos los campos son obligatorios");
        }

        var persona = new Persona
        {
            Nombre = request.Nombre,
            Ci = request.Ci,
            Estado = request.Estado
        };

        _context.Personas.Add(persona);
        await _context.SaveChangesAsync();

        return StatusCode(201, persona);
    }
}

public class CrearPersonaRequest
{
    public string Nombre { get; set; } = string.Empty;
    public string Ci { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}
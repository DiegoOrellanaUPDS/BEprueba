using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BEPrueba.Dominio;
using BEPrueba.Data;

namespace BEPrueba.Controllers;

[ApiController]
[Route("api/h13")]
public class ControladorOvidioController : ControllerBase
{
    private readonly DBContext _context;

    public ControladorOvidioController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var personas = await _context.Personas.ToListAsync();
        return Ok(personas);
    }
}
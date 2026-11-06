using BEPrueba.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BEPrueba.Data;
[ApiController]
[Route("api/[controller]")]
public class PersonaController: ControllerBase{
    private readonly DBContext _context;
    public PersonaController(DBContext context){
        this._context=context;
    }
    [HttpGet("Listar")]
    public async Task<IActionResult> GetPersonas(){
        var personas= await _context.Personas.ToListAsync();
        return Ok(personas);
    }

}
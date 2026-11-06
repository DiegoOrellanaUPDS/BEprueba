using System;
using System.ComponentModel.DataAnnotations;

namespace BEPrueba.Dominio;

public class Persona
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Ci { get; set; }
    public string Estado { get; set; }
}

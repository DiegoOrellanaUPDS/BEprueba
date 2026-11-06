using System;
using BEPrueba.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BEPrueba.Data;

public class DBContext: DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
    public DbSet<Persona> Personas { get; set; }
}

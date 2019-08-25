using Institucion.Models;
using System.Data.Entity;

namespace Institucion.DataAccess
{
    public class InstitucionDataContext : DbContext
    {
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

        public InstitucionDataContext(): base("platziSharp")
        {

        }
    }
}

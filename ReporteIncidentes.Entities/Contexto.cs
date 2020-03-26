using Microsoft.EntityFrameworkCore;

namespace ReporteIncidentes.Entities
{
    public class Contexto : DbContext
    {
        /// <summary>
        /// Constructor del contexto de datos
        /// </summary>
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

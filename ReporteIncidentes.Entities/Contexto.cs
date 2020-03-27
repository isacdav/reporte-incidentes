using Microsoft.EntityFrameworkCore;

namespace ReporteIncidentes.Entities
{
    public class Contexto : DbContext
    {
        /// <summary>
        /// Constructor del contexto de datos
        /// </summary>
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<DatosUsuario> datosUsuarios { get; set; }

        public DbSet<EstadoUsuario> estadoUsuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatosUsuario>(entity=> 
            {
                entity.Property(e => e.IdUsuario).HasColumnName("IdUsuario");
	            entity.Property(e=>e.Cedula).HasColumnName("Cedula");
                entity.Property(e=>e.Nombre).HasColumnName("Nombre");
                entity.Property(e=>e.Apellidos).HasColumnName("Apellidos");
                entity.Property(e=>e.Provincia).HasColumnName("Provincia");
                entity.Property(e=>e.Canton).HasColumnName("Canton");
                entity.Property(e=>e.Distrito).HasColumnName("Distrito");
                entity.Property(e=>e.Direccion).HasColumnName("Direccion");
                entity.Property(e=>e.CorreoElectronico).HasColumnName("CorreoElectronico");
                entity.HasKey(e => e.CorreoElectronico).HasName("CorreoElectronico");
                entity.Property(e=>e.Telefono).HasColumnName("Telefono");
                entity.Property(e=>e.Contrasena).HasColumnName("Contrasena");
                entity.Property(e=>e.EstadoUsuario).HasColumnName("EstadoUsuario");
                entity.Property(e=>e.CodigoActivacion).HasColumnName("CodigoActivacion");
            });

            modelBuilder.Entity<EstadoUsuario>(entity=>
            {
                entity.Property(e=>e.Resultado).HasColumnName("Resultado");
                entity.HasKey(e=>e.Resultado).HasName("Resultado");
            });
        }
    }
}

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

        public DbSet<Incidencias> Incidencias { get; set; }


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

            modelBuilder.Entity<Incidencias>(entity=>
            {
                entity.Property(e => e.IdIncidencia).HasColumnName("IdIncidencia");
                entity.HasKey(e => e.IdIncidencia).HasName("IdIncidencia");
	            entity.Property(e=>e.IdUsuario).HasColumnName("IdUsuario");
                entity.Property(e=>e.Categoria).HasColumnName("Categoria");
                entity.Property(e=>e.Empresa).HasColumnName("Empresa");
                entity.Property(e=>e.Provincia).HasColumnName("Provincia");
                entity.Property(e=>e.Canton).HasColumnName("Canton");
                entity.Property(e=>e.Distrito).HasColumnName("Distrito");
                entity.Property(e=>e.DireccionExacta).HasColumnName("DireccionExacta");
                entity.Property(e=>e.Latitud).HasColumnName("Latitud");
                entity.Property(e=>e.Longitud).HasColumnName("Longitud");
                entity.Property(e=>e.RutaImagen1).HasColumnName("RutaImagen1");
                entity.Property(e=>e.RutaImagen2).HasColumnName("RutaImagen2");
                entity.Property(e=>e.RutaImagen3).HasColumnName("RutaImagen3");
                entity.Property(e=>e.RutaImagen4).HasColumnName("RutaImagen4");
                entity.Property(e=>e.DetalleIncidencia).HasColumnName("DetalleIncidencia");
                entity.Property(e=>e.Estado).HasColumnName("Estado");
            });
        }
    }
}

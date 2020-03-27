using Microsoft.EntityFrameworkCore;
using ReporteIncidentes.Entities;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace ReporteIncidentes.DAL
{
    public class UsuariosDAL
    {
        private readonly Contexto _contexto;
        /// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="contexto"></param>
        public UsuariosDAL(Contexto contexto)
        {
            _contexto = contexto;
        }
		/// <summary>
		/// Método para insertar el usuario en la base de datos
		/// </summary>
		/// <param name="oUsuario"></param>
		/// <returns></returns>
		public Respuesta<bool> InsertarUsuario(DatosUsuario oUsuario)
		{
			Respuesta<bool> respuesta = new Respuesta<bool>();
			using (TransactionScope transaccion = new TransactionScope())
			{
				try
				{
					string SQL = @"EXEC Pa_InsertarUsurio @Cedula, @Nombre, @Apellidos, @Provincia,
									@Canton, @Distrito, @Direccion, @CorreoElectronico, @Telefono,
									@Contrasena, @CodigoActvacion ";
					 _contexto.Database.ExecuteSqlCommand(SQL,
						new SqlParameter("@Cedula", oUsuario.Cedula),
						new SqlParameter("@Nombre", oUsuario.Provincia),
						new SqlParameter("@Apellidos", oUsuario.Apellidos),
						new SqlParameter("@Provincia", oUsuario.Provincia),
						new SqlParameter("@Canton", oUsuario.Canton),
						new SqlParameter("@Distrito", oUsuario.Distrito),
						new SqlParameter("@Direccion", oUsuario.Direccion),
						new SqlParameter("@CorreoElectronico", oUsuario.CorreoElectronico),
						new SqlParameter("@Telefono", oUsuario.Telefono),
						new SqlParameter("@Contrasena", oUsuario.Contrasena),
						new SqlParameter("@CodigoActvacion", oUsuario.CodigoActivacion),
					_contexto.SaveChanges());
					transaccion.Complete();
					respuesta.HayError = false;
					respuesta.ObjetoRespuesta = true;
				}
				catch (Exception ex)
				{
					transaccion.Dispose();
					respuesta.HayError = true;
					respuesta.MensajeError = ex.Message;
					respuesta.ObjetoRespuesta = false;
				}
			}
			return respuesta;
		}
		/// <summary>
		/// Método de LogIn
		/// </summary>
		/// <param name="Usuario"></param>
		/// <returns></returns>
		public Respuesta<DatosUsuario> LogIn(DatosUsuario oUsuario)
		{
			Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
			using (TransactionScope transaccion= new TransactionScope())
			{
				try
				{
					string SQL = @"EXEC Pa_LogIn @Contrasena,  @CorreoElectronico";
					respuesta.ObjetoRespuesta = _contexto.Set<Entities.DatosUsuario>().
						FromSql(SQL,
					   new SqlParameter("@CorreoElectronico", oUsuario.CorreoElectronico),
					   new SqlParameter("@Contrasena", oUsuario.Contrasena)).FirstOrDefault();
				   _contexto.SaveChanges();
					transaccion.Complete();
					respuesta.HayError = false;					
				}
				catch (Exception ex)
				{
					transaccion.Dispose();
					respuesta.HayError = true;
					respuesta.MensajeError = ex.Message;
				}
			}
			return respuesta;
		}
		/// <summary>
		/// Método para activar el usuario
		/// </summary>
		/// <param name="oUsuario"></param>
		/// <returns></returns>
		public Respuesta<DatosUsuario> ActivarUsuario(DatosUsuario oUsuario)
		{
			Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
			using (TransactionScope transaccion = new TransactionScope())
			{
				try
				{
					string SQL = @"EXEC Pa_ActivarEstadousuario  @CorreoElectronico, @CodigoActvacion ";
					var resultado= _contexto.Set<EstadoUsuario>().
						FromSql(SQL,
					   new SqlParameter("@CorreoElectronico", oUsuario.CorreoElectronico),
					   new SqlParameter("@CodigoActvacion", oUsuario.CodigoActivacion),
				   _contexto.SaveChanges()).FirstOrDefault();
					transaccion.Complete();
					respuesta.HayError = false;
					if (resultado.Resultado.Equals("Usuario activado correctamente"))
					{
						respuesta.ObjetoRespuesta = oUsuario;
						respuesta.ObjetoRespuesta.EstadoUsuario = "A";
					}
					respuesta.Mensaje = resultado.Resultado; 
				}
				catch (Exception ex)
				{
					transaccion.Dispose();
					respuesta.HayError = true;
					respuesta.MensajeError = ex.Message;
				}
			}
			return respuesta;
		}
	}
}

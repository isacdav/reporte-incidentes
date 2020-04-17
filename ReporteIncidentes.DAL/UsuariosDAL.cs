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
			TransactionScope transaccion = new TransactionScope();
			DatosUsuario usuario = new DatosUsuario();
			try
			{
				using (transaccion)
				{
					string SQL2 = @"EXEC Pa_ConsultarUsuario  @CorreoElectronico ";
					usuario = _contexto.Set<DatosUsuario>().
						FromSql(SQL2,
					   new SqlParameter("@CorreoElectronico", oUsuario.CorreoElectronico),
					_contexto.SaveChanges()).FirstOrDefault();
					transaccion.Complete();
					if (usuario != null)
					{
						respuesta.ObjetoRespuesta = false;
						respuesta.HayError = false;
						respuesta.Mensaje = "Ya existe un usuario registrado con esa dirección de email";
					}					
				}

				if (usuario==null)
				{
					using (transaccion= new TransactionScope())
					{
						string SQL = @"EXEC Pa_InsertarUsurio @Cedula, @Nombre, @Apellidos, @Provincia,
								@Direccion, @CorreoElectronico, @Telefono,
								@Contrasena, @CodigoActvacion ";
						_contexto.Database.ExecuteSqlCommand(SQL,
						   new SqlParameter("@Cedula", oUsuario.Cedula),
						   new SqlParameter("@Nombre", oUsuario.Nombre),
						   new SqlParameter("@Apellidos", oUsuario.Apellidos),
						   new SqlParameter("@Provincia", oUsuario.Provincia),
						   new SqlParameter("@Direccion", oUsuario.Direccion),
						   new SqlParameter("@CorreoElectronico", oUsuario.CorreoElectronico),
						   new SqlParameter("@Telefono", oUsuario.Telefono),
						   new SqlParameter("@Contrasena", oUsuario.Contrasena),
						   new SqlParameter("@CodigoActvacion", oUsuario.CodigoActivacion),
					   _contexto.SaveChanges());
						transaccion.Complete();
						respuesta.HayError = false;
						respuesta.ObjetoRespuesta = true;
						respuesta.Mensaje = "¡Felicidades, su usuario se ha registrado correctamente!";
					}
				}
				
			}
			catch (Exception ex)
			{
				transaccion.Dispose();
				respuesta.HayError = true;
				respuesta.MensajeError = ex.Message;
				respuesta.ObjetoRespuesta = false;
			}
			return respuesta;
		}
		/// <summary>
		/// Método de LogIn
		/// </summary>
		/// <param name="Usuario"></param>
		/// <returns></returns>
		public Respuesta<DatosUsuario> LogIn(string correo, string contrasena)
		{
			Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
			using (TransactionScope transaccion= new TransactionScope())
			{
				try
				{
					string SQL = @"EXEC Pa_LogIn @Contrasena,  @CorreoElectronico";
					respuesta.ObjetoRespuesta = _contexto.Set<Entities.DatosUsuario>().
						FromSql(SQL,
					   new SqlParameter("@CorreoElectronico", correo),
					   new SqlParameter("@Contrasena", contrasena)).FirstOrDefault();
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
		public Respuesta<DatosUsuario> ActivarUsuario(string correoElectronico, int codigoActivacion)
		{
			Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
			TransactionScope transaccion= new TransactionScope();
			try
			{
				var resultado=new EstadoUsuario();
				using (transaccion)
				{
					string SQL = @"EXEC Pa_ActivarEstadousuario  @CorreoElectronico, @CodigoActvacion ";
					resultado= _contexto.Set<EstadoUsuario>().
						FromSql(SQL,
					   new SqlParameter("@CorreoElectronico", correoElectronico),
					   new SqlParameter("@CodigoActvacion", codigoActivacion),
				   _contexto.SaveChanges()).FirstOrDefault();
					transaccion.Complete();
					respuesta.HayError = false;
				
				}

				if (resultado.Resultado.Equals("Usuario activado correctamente"))
				{
					using (transaccion = new TransactionScope())
					{
						string SQL2 = @"EXEC Pa_ConsultarUsuario  @CorreoElectronico ";
						var resultado2 = _contexto.Set<DatosUsuario>().
							FromSql(SQL2,
						   new SqlParameter("@CorreoElectronico", correoElectronico),
						_contexto.SaveChanges()).FirstOrDefault();
						respuesta.ObjetoRespuesta = resultado2;
						transaccion.Complete();
						respuesta.HayError = false;
					}
				}
				respuesta.Mensaje = resultado.Resultado;
			}
			catch (Exception ex)
			{
				transaccion.Dispose();
				respuesta.HayError = true;
				respuesta.MensajeError = ex.Message;
			}
			return respuesta;
		}
	}
}

using ReporteIncidentes.DAL;
using ReporteIncidentes.Entities;
using System;

namespace ReportesIncidentes.BL
{
	public class UsuariosBL
    {
		private readonly Contexto _contexto;
		UsuariosDAL oUsuarios;
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="contexto"></param>
		public UsuariosBL(Contexto contexto)
		{
			_contexto = contexto;
		}
		/// <summary>
		/// Método para insertar el usuario en la base de datos
		/// </summary>
		/// <param name="usuario"></param>
		/// <returns></returns>
		public Respuesta<bool> InsertarUsuario(DatosUsuario usuario)
        {
			Respuesta<bool> respuesta = new Respuesta<bool>();
			try
			{
				oUsuarios = new UsuariosDAL(_contexto);
				respuesta = oUsuarios.InsertarUsuario(usuario);
			}
			catch (Exception ex)
			{
				respuesta.HayError = true;
				respuesta.MensajeError = ex.Message;
				respuesta.ObjetoRespuesta = false;
			}
			return respuesta;
        }
		/// <summary>
		/// Método de LogIn
		/// </summary>
		/// <param name="usuario"></param>
		/// <returns></returns>
		public Respuesta<DatosUsuario> LogIn(DatosUsuario usuario)
		{
			Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
			try
			{
				oUsuarios = new UsuariosDAL(_contexto);
				respuesta = oUsuarios.LogIn(usuario);
			}
			catch (Exception ex)
			{
				respuesta.HayError = true;
				respuesta.MensajeError = ex.Message;
			}
			return respuesta;
		}
		/// <summary>
		/// Método utilizado para activar el usuario
		/// </summary>
		/// <param name="usuario"></param>
		/// <returns></returns>
		public Respuesta<DatosUsuario> ActivarUsuario(DatosUsuario usuario)
		{
			Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
			try
			{
				oUsuarios = new UsuariosDAL(_contexto);
				respuesta = oUsuarios.ActivarUsuario(usuario);
			}
			catch (Exception ex)
			{
				respuesta.HayError = true;
				respuesta.MensajeError = ex.Message;
			}
			return respuesta;
		}
	}
}

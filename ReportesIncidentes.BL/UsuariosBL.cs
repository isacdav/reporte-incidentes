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
				usuario.Contrasena = CifradoHash256.HmacSHA512(usuario.Contrasena);
				usuario.CodigoActivacion = Utilitarios.GenerarCodigoActivacion();
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
		public Respuesta<DatosUsuario> LogIn(string correo, string contrasena)
		{
			Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
			try
			{
				oUsuarios = new UsuariosDAL(_contexto);
				contrasena = CifradoHash256.HmacSHA512(contrasena);
				respuesta = oUsuarios.LogIn(correo, contrasena);
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
		public Respuesta<DatosUsuario> ActivarUsuario(string correoelectronico, int codigoActivacion)
		{
			Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
			try
			{
				oUsuarios = new UsuariosDAL(_contexto);
				respuesta = oUsuarios.ActivarUsuario(correoelectronico, codigoActivacion);
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

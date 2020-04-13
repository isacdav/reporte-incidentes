using Newtonsoft.Json;
using ReporteIncidentes.DAL;
using ReporteIncidentes.Entities;
using System;
using System.Threading.Tasks;
using Verifalia.Api;
using Verifalia.Api.EmailValidations;

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
				if (!respuesta.HayError && respuesta.ObjetoRespuesta)
				{
					Utilitarios.EnviarEmail(usuario.CorreoElectronico,usuario.Nombre,usuario.Apellidos,usuario.CodigoActivacion);
				}
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
		/// <summary>
		/// Método utilizado para validar la dirección del email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public async Task<Respuesta<string>> VerificarEmail(string email)
		{
			Respuesta<string> respuesta = new Respuesta<string>();
			try
			{
				var verifalia = new VerifaliaRestClient(CifradoAES.DescifrarAES(Configuracion.Leer("EmailApp")),
					CifradoAES.DescifrarAES(Configuracion.Leer("Contrasena")));
				var validation = await verifalia
										.EmailValidations
										.SubmitAsync(email,waitingStrategy: new WaitingStrategy(true));
				respuesta.HayError = false;
				//respuesta.IdError = validation.Entries[0].Status;
				respuesta.ObjetoRespuesta = JsonConvert.SerializeObject(validation.Entries[0]); 
				respuesta.Mensaje = validation.Entries[0].Status.ToString();
			}
			catch (Exception ex)
			{
				respuesta.HayError = true;
				respuesta.MensajeError = ex.Message;
				respuesta.ObjetoRespuesta = string.Empty;
			}
			return respuesta;
		}
	}
}

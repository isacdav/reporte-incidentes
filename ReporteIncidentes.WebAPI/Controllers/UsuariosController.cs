using Microsoft.AspNetCore.Mvc;
using ReporteIncidentes.Entities;
using ReportesIncidentes.BL;
using System;

namespace ReporteIncidentes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly Contexto _contexto;
        UsuariosBL oUsuarios;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contexto"></param>
        public UsuariosController(Contexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Método encargado de insertar el usuario
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public Respuesta<bool> InsertarUsuario(DatosUsuario usuario)
        {
            Respuesta<bool> respuesta = new Respuesta<bool>();
            try
            {
                oUsuarios = new UsuariosBL(_contexto);
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
        /// Método encargado de realizar el LogIn
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public Respuesta<DatosUsuario> LogIn(DatosUsuario usuario)
        {
            Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
            try
            {
                oUsuarios = new UsuariosBL(_contexto);
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
        /// Método encargado de activar el usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public Respuesta<DatosUsuario> ActivarUsuario(DatosUsuario usuario)
        {
            Respuesta<DatosUsuario> respuesta = new Respuesta<DatosUsuario>();
            try
            {
                oUsuarios = new UsuariosBL(_contexto);
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

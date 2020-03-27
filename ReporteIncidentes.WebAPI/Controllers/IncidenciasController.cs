using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReporteIncidentes.Entities;
using ReportesIncidentes.BL;

namespace ReporteIncidentes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciasController : Controller
    {
        private readonly Contexto _contexto;
        IncidenciasBL oIncidencias;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contexto"></param>
        public IncidenciasController(Contexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Método encargado de almacenar la incidencias
        /// </summary>
        /// <param name="incidencias"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public Respuesta<bool> InsertarIncidencias(Incidencias incidencias)
        {
            Respuesta<bool> respuesta = new Respuesta<bool>();
            try
            {
                oIncidencias = new IncidenciasBL(_contexto);
                respuesta = oIncidencias.InsertarIncidencias(incidencias);
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
        /// Método que consulta la incidencia
        /// </summary>
        /// <param name="incidencias"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public Respuesta<List<Incidencias>> ConsultarIncidenciasUsuario(Incidencias incidencias)
        {
            Respuesta<List<Incidencias>> respuesta = new Respuesta<List<Incidencias>>();
            try
            {
                oIncidencias = new IncidenciasBL(_contexto);
                respuesta = oIncidencias.ConsultarIncidenciasUsuario(incidencias);
            }
            catch (Exception ex)
            {
                respuesta.HayError = true;
                respuesta.MensajeError = ex.Message;
            }
            return respuesta;
        }
        /// <summary>
        /// Método que cambia el estado de la incidencia
        /// </summary>
        /// <param name="incidencias"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public Respuesta<Incidencias> CambiarEstadoIncidencia(Incidencias incidencias)
        {
            Respuesta<Incidencias> respuesta = new Respuesta<Incidencias>();
            try
            {
                oIncidencias = new IncidenciasBL(_contexto);
                respuesta = oIncidencias.CambiarEstadoIncidencia(incidencias);
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

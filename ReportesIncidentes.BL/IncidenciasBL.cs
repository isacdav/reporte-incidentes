using ReporteIncidentes.DAL;
using ReporteIncidentes.Entities;
using System;
using System.Collections.Generic;

namespace ReportesIncidentes.BL
{
    public class IncidenciasBL
    {
        private readonly Contexto _contexto;
        IncidenciasDAL oIncidencias;
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="contexto"></param>
		public IncidenciasBL(Contexto contexto)
		{
			_contexto = contexto;
		}
		/// <summary>
		/// Método que almacena la incidencia
		/// </summary>
		/// <param name="incidencias"></param>
		/// <returns></returns>
		public Respuesta<bool> InsertarIncidencias(Incidencias incidencias)
		{
			Respuesta<bool> respuesta = new Respuesta<bool>();
			try
			{
				oIncidencias = new IncidenciasDAL(_contexto);
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
		/// Método que consulta las incidencias
		/// </summary>
		/// <param name="incidencias"></param>
		/// <returns></returns>
		public Respuesta<List<Incidencias>> ConsultarIncidenciasUsuario(Incidencias incidencias)
		{
			Respuesta<List<Incidencias>> respuesta = new Respuesta<List<Incidencias>>();
			try
			{
				oIncidencias = new IncidenciasDAL(_contexto);
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
		/// Método que le cambia el estado a la incidencia
		/// </summary>
		/// <param name="incidencias"></param>
		/// <returns></returns>
		public Respuesta<Incidencias> CambiarEstadoIncidencia(Incidencias incidencias)
		{
			Respuesta<Incidencias> respuesta = new Respuesta<Incidencias>();
			try
			{
				oIncidencias = new IncidenciasDAL(_contexto);
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

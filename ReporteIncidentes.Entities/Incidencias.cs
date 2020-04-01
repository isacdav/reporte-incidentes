using System;
using System.Runtime.Serialization;

namespace ReporteIncidentes.Entities
{
    [DataContract]
    [Serializable]
    public class Incidencias
    {
		/// <summary>
		/// Id autogenerado de la incidencia
		/// </summary>
		[DataMember]
		public int IdIncidencia { get; set; }
		/// <summary>
		/// id del usuario que registra
		/// </summary>
		[DataMember]
		public int IdUsuario { get; set; }
		/// <summary>
		/// categoria de la incidencia
		/// </summary>
		[DataMember]
		public string Categoria { get; set; }
		/// <summary>
		/// Empresa responsable
		/// </summary>
		[DataMember]
		public string Empresa { get; set; }
		/// <summary>
		/// Provincia en la que se registra la incidencia
		/// </summary>
		[DataMember]
		public string Provincia { get; set; }
		/// <summary>
		/// Canton en el que se registra la incidencia
		/// </summary>
		[DataMember]
		public string Canton { get; set; }
		/// <summary>
		/// Distrito en el que se registra la incidencia
		/// </summary>
		[DataMember]
		public string Distrito { get; set; }
		/// <summary>
		/// Dirección exacta de la incidencia
		/// </summary>
		[DataMember]
		public string DireccionExacta { get; set; }
		/// <summary>
		/// Latitud
		/// </summary>
		[DataMember]
		public decimal Latitud { get; set; }
		/// <summary>
		/// Longitud
		/// </summary>
		[DataMember]
		public decimal Longitud { get; set; }
		/// <summary>
		/// Ruta donde se almacenan las imagenes
		/// </summary>
		[DataMember]
		public string RutaImagen1 { get; set; }
		/// <summary>
		/// Ruta donde se almacenan las imagenes
		/// </summary>
		[DataMember]
		public string RutaImagen2 { get; set; }
		/// <summary>
		/// Ruta donde se almacenan las imagenes
		/// </summary>
		[DataMember]
		public string RutaImagen3 { get; set; }
		/// <summary>
		/// Ruta donde se almacenan las imagenes
		/// </summary>
		[DataMember]
		public string RutaImagen4 { get; set; }
		/// <summary>
		/// Detalle de la incidencia
		/// </summary>
		[DataMember]
		public string DetalleIncidencia { get; set; }
		/// <summary>
		/// Estado de la incidencia
		/// </summary>
		[DataMember]
		public string Estado { get; set; }
	}
}

using System;
using System.Runtime.Serialization;

namespace ReporteIncidentes.Entities
{
    [DataContract]
    [Serializable]
    public class DatosUsuario
    {
		/// <summary>
		/// Id unico del usuario
		/// </summary>
        [DataMember]
		public int IdUsuario { get; set; }
		/// <summary>
		/// Cedula del usuario
		/// </summary>
		[DataMember]
		public string Cedula { get; set; }
		/// <summary>
		/// Nombre del usuario
		/// </summary>
		[DataMember]
		public string Nombre { get; set; }
		/// <summary>
		/// Apellidos del usuario
		/// </summary>
		[DataMember]
		public string Apellidos { get; set; }
		/// <summary>
		/// Provincia en donde vive el usuario
		/// </summary>
		[DataMember]
		public string Provincia { get; set; }		
		/// <summary>
		/// Direccion exacta de la residencia del usuario
		/// </summary>
		[DataMember]
		public string Direccion { get; set; }
		/// <summary>
		/// Correo electronico del usuario
		/// </summary>
		[DataMember]
		public string CorreoElectronico { get; set; }
		/// <summary>
		/// Numero de telefono del usuario
		/// </summary>
		[DataMember]
		public string Telefono { get; set; }
		/// <summary>
		/// Constraseña de acceso
		/// </summary>
		[DataMember]
		public string Contrasena { get; set; }
		/// <summary>
		/// Estado del usuario (Registrado, Activo, Inactivo)
		/// </summary>
		[DataMember]
		public string EstadoUsuario { get; set; }
		/// <summary>
		/// Código de activación de la cuenta de usuario
		/// </summary>
		[DataMember]
		public int CodigoActivacion { get; set; }

	}
}

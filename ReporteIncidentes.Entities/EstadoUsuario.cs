using System;
using System.Runtime.Serialization;

namespace ReporteIncidentes.Entities
{
    [DataContract]
    [Serializable]
    public class EstadoUsuario
    {
        /// <summary>
        /// Resultado del proceso de activación
        /// </summary>
        [DataMember]
        public string Resultado { get; set; }
    }
}

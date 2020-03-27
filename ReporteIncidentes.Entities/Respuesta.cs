namespace ReporteIncidentes.Entities
{
    public class Respuesta<T>
    {
        public bool HayError { get; set; }

        public string Mensaje { get; set; }

        public string MensajeError { get; set; }

        public string MensajeErrorDetallado { get; set; }

        public int IdError { get; set; }

        public T ObjetoRespuesta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ReportesIncidentes.BL
{
    public static class Utilitarios
    {
        /// <summary>
        /// Método que genera los códigos de actctivación 
        /// </summary>
        /// <returns></returns>
        public static int GenerarCodigoActivacion()
        {
            Random rdn = new Random();
            return rdn.Next(999999);
        }
    }
}

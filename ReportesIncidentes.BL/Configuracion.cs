using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReportesIncidentes.BL
{
    public static class Configuracion
    {
        #region Atributos

        /// <summary>
        /// Elemento raíz de la configuración.
        /// </summary>
        private static readonly IConfiguration Root;

        #endregion Atributos

        #region CTOR
        /// <summary>
        /// Método constructor de la clase
        /// </summary>
        static Configuracion()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            builder.AddJsonFile(path, false);

            Root = builder.Build();
        }

        #endregion CTOR

        #region Propiedades Públicas

        /// <summary>
        /// Método encargado de ir a leer el archivo de configuracion y traer el valor contenido en la llave
        /// </summary>
        /// <param name="llave"></param>
        /// <returns></returns>
        public static string Leer(string llave)
        {
            return Root[llave];
        }

        #endregion Propiedades Públicas

    }
}


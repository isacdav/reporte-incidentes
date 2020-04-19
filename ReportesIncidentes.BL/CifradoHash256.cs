using System;
using System.Security.Cryptography;
using System.Text;

namespace ReportesIncidentes.BL
{
    public static class CifradoHash256
    {
        /// <summary>
        /// Método que crea un hash basado en MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HmacSHA512(string input)
        {
            using (HMACSHA512 hmac = new HMACSHA512(Encoding.ASCII.GetBytes(Configuracion.Leer("llave"))))
            {
                return ByteToString(hmac.ComputeHash(Encoding.ASCII.GetBytes(input)));
            }
        }
        /// <summary>
        /// Método para pasar los bytes a string
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); /* hex format */
            }
            return (sbinary);
        }
    }
}

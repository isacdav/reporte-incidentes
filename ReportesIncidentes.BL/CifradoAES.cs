using Microsoft.Extensions.Configuration;
using ReporteIncidentes.Entities;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ReportesIncidentes.BL
{
    /// <summary> 
    /// Métodos encargado de descifrar y cifrar las cadenas de conexión para BIAC.
    /// </summary>
    /// <creator>Steven Guevara Carrillo</creator>
    /// <createddate>18-02-2020</createddate> 
    public static class CifradoAES
    {
        /// <summary>
        /// Método encargado de cifrar los datos
        /// </summary>
        /// <param name="bytesACifrar"></param>
        /// <param name="bytesContraseña"></param>
        /// <returns>bytes de los datos cifrados</returns>
        public static string cifrarAES(string texto)
        {
            string resultado = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    string llave = Configuracion.Leer("llave");

                    byte[] bytesEncriptar = Encoding.UTF8.GetBytes(texto);
                    byte[] bytesContrasena = Encoding.UTF8.GetBytes(llave);

                    bytesContrasena = SHA256.Create().ComputeHash(bytesContrasena);

                    byte[] bytesEncrypted = CifrarAES(bytesEncriptar, bytesContrasena);

                    resultado = Convert.ToBase64String(bytesEncrypted);
                }
                else
                {
                    resultado = string.Empty;
                }
            }
            catch (Exception)
            {
                resultado = string.Empty;
            }
            return resultado;
        }
        /// <summary>
        /// Método encargado de descifrar los datos
        /// </summary>
        /// <param name="byteDecifrar"></param>
        /// <param name="bytesContraseña"></param>
        /// <returns>Arreglo de byets con la información descifrada</returns>
        public static string DescifrarAES(string texto)
        {
            string resultado = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    string llave = Configuracion.Leer("llave");

                    byte[] bytesDescifrar = Convert.FromBase64String(texto);
                    byte[] bytesContrasena = Encoding.UTF8.GetBytes(llave);
                    bytesContrasena = SHA256.Create().ComputeHash(bytesContrasena);

                    byte[] bytesDecrypted = DescifrarAES(bytesDescifrar, bytesContrasena);

                    resultado = Encoding.UTF8.GetString(bytesDecrypted);
                }
                else
                {
                    resultado = string.Empty;
                }
            }
            catch (Exception)
            {
                resultado = string.Empty;
            }
            return resultado;
        }

        /// <summary>
        /// Método encargado de cifrar los datos
        /// </summary>
        /// <param name="bytesACifrar"></param>
        /// <param name="bytesContraseña"></param>
        /// <returns>bytes de los datos cifrados</returns>
        private static byte[] CifrarAES(byte[] bytesACifrar, byte[] bytesContraseña)
        {
            byte[] bytesCifrados = null;

            byte[] bytesSalto = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(bytesContraseña, bytesSalto, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesACifrar, 0, bytesACifrar.Length);
                        cs.Close();
                    }
                    bytesCifrados = ms.ToArray();
                }
            }

            return bytesCifrados;
        }
        /// <summary>
        /// Método encargado de descifrar los datos
        /// </summary>
        /// <param name="byteDecifrar"></param>
        /// <param name="bytesContraseña"></param>
        /// <returns>Arreglo de byets con la información descifrada</returns>
        private static byte[] DescifrarAES(byte[] byteDecifrar, byte[] bytesContraseña)
        {
            byte[] bytesDescifrados = null;

            byte[] bytesSalto = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(bytesContraseña, bytesSalto, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(byteDecifrar, 0, byteDecifrar.Length);
                        cs.Close();
                    }
                    bytesDescifrados = ms.ToArray();
                }
            }

            return bytesDescifrados;
        }
    }
}

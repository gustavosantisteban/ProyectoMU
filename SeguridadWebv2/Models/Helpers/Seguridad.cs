using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguridadWebv2.Models.Helpers
{
    public static class Seguridad
    {
        public static string ClaveAleatoria()
        {
            char[] ValueAfanumeric = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            Random random = new Random();
            int longitud = 6;
            string ClaveAleat = String.Empty;
            for (int i = 0; i < longitud; i++)
            {
                int rm = random.Next(0, 2);
                if (rm == 0)
                {
                    ClaveAleat += "M" + random.Next(0, 5) + "@" + random.Next(0, 5);
                }
                else
                {
                    ClaveAleat += ValueAfanumeric[random.Next(0, 59)];
                }
            }
            return ClaveAleat;
        }

        public static string Encriptar(string clave)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider encripta = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(clave);
            data = encripta.ComputeHash(data);
            String md5Hash = System.Text.Encoding.ASCII.GetString(data);

            return md5Hash;
        }

        /// Encripta una cadena
        public static string EncriptarBase64(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
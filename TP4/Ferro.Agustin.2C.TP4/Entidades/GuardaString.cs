using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension que graba el String que lo llama en el archivo ingresado por parametro
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool success = false;
            string ruta = String.Format("{0}\\{1}", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), archivo);
            StreamWriter sw = new StreamWriter(ruta, File.Exists(ruta));
            try
            {
                sw.WriteLine(texto);
                success = true;
            }
            catch(Exception e)
            {
                success = false;
                throw new Exception("No se pudo guardar el texto en el archivo",e);
            }
            finally
            {
                sw.Close();
            }
            return success;
        }
    }
}

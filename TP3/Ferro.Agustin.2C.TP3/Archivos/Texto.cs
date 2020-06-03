using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Metodo que guarda un string en un texto
        /// </summary>
        /// <param name="texto">string path del texto</param>
        /// <param name="datos">string datos</param>
        /// <returns>bool</returns>
        public bool Guardar(string texto, string datos)
        {
            StreamWriter sw = new StreamWriter(texto);
            bool success = false;
            try
            {
                sw.Write(datos);
                success = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            finally
            {
                sw.Close();   
            }
            return success;
        }
        /// <summary>
        /// Metodo que lee un archivo
        /// </summary>
        /// <param name="texto">string path del texto</param>
        /// <param name="datos">string datos</param>
        /// <returns>bool y el string con los datos</returns>
        public bool Leer(string texto, out string datos)
        {
            StreamReader sr = new StreamReader(texto);
            bool success = false;
            try
            {
                datos = sr.ReadToEnd();
                success = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            finally
            {
                sr.Close();
            }
            return success;
        }
    }
}

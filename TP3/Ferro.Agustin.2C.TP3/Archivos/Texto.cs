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

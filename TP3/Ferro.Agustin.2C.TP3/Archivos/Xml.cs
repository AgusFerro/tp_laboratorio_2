using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo que guarda en formato XML un objeto
        /// </summary>
        /// <param name="texto">string path del archivo xml</param>
        /// <param name="datos">T datos</param>
        /// <returns>bool</returns>
        public bool Guardar(string texto, T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextWriter writer = new XmlTextWriter(texto, Encoding.UTF8);
            bool success = false;
            try
            {
                ser.Serialize(writer, datos);
                success = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                writer.Close();
            }
            return success;
        }
        /// <summary>
        /// Metodo que lee un archivo XML
        /// </summary>
        /// <param name="texto">string path del archivo</param>
        /// <param name="datos">T datos</param>
        /// <returns>bool y T datos</returns>
        public bool Leer(string texto, out T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextReader reader = new XmlTextReader(texto);
            bool success = false;
            try
            {
                datos = (T)ser.Deserialize(reader);
                success = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                reader.Close();
            }
            return success;
        }
    }
}

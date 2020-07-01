using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Metodo de la interfaz IMostrar que muestra los datos de ese elemento
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}

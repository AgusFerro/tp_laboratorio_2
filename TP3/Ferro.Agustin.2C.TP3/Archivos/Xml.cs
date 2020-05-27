using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string texto, T datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string texto, out T datos)
        {
            throw new NotImplementedException();
        }
    }
}

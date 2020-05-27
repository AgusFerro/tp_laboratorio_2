using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        bool Guardar(string texto, T datos);
        bool Leer(string texto, out T datos);
    }
}

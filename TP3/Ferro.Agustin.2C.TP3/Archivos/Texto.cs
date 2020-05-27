using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string texto, string datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string texto, out string datos)
        {
            throw new NotImplementedException();
        }
    }
}

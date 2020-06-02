using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException() : this("No hay profesor disponible")
        { }

        public SinProfesorException(string mensaje) : base(mensaje)
        { }
    }
}

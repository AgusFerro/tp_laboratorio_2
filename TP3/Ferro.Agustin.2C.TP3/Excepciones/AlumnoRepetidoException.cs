using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : this("El alumno esta repetido")
        { }

        public AlumnoRepetidoException(string mensaje) : base(mensaje)
        { }

    }
}

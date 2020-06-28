using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIDRepetidoException : Exception
    {
        public TrackingIDRepetidoException(string mensaje) : base(mensaje)
        { }
        public TrackingIDRepetidoException(string mensaje, Exception innerException) : base(mensaje,innerException)
        { }
    }
}

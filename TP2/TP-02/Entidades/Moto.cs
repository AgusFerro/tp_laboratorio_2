using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        public Moto(EMarca marca, string codigo, ConsoleColor color) : base(codigo,marca,color)
        { }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        public override string Mostrar()
        {
            StringBuilder cadenaMoto = new StringBuilder();

            cadenaMoto.AppendLine("MOTO");
            cadenaMoto.AppendLine(base.Mostrar());
            cadenaMoto.AppendLine($"TAMAÑO : {this.Tamanio}");
            cadenaMoto.AppendLine("");
            cadenaMoto.AppendLine("---------------------");

            return cadenaMoto.ToString();
        }
    }
}

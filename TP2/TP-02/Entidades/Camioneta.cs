using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        public Camioneta(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
        }
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        public override string Mostrar()
        {
            StringBuilder cadenaCamioneta = new StringBuilder();

            cadenaCamioneta.AppendLine("CAMIONETA");
            cadenaCamioneta.AppendLine(base.Mostrar());
            cadenaCamioneta.AppendLine($"TAMAÑO : {this.Tamanio}");
            cadenaCamioneta.AppendLine("");
            cadenaCamioneta.AppendLine("---------------------");

            return cadenaCamioneta.ToString();
        }
    }
}

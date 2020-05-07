using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        public enum ETipo { Monovolumen, Sedan }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string codigo, ConsoleColor color) : this(marca,codigo,color,ETipo.Monovolumen)   
        { }
        public Automovil(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        public override string Mostrar()
        {
            StringBuilder cadenaAutomovil = new StringBuilder();

            cadenaAutomovil.AppendLine("AUTOMOVIL");
            cadenaAutomovil.AppendLine(base.Mostrar());
            cadenaAutomovil.AppendLine($"TAMAÑO : {this.Tamanio}"+$" TIPO : {this.tipo}");
            cadenaAutomovil.AppendLine("");
            cadenaAutomovil.AppendLine("---------------------");

            return cadenaAutomovil.ToString();
        }
    }
}

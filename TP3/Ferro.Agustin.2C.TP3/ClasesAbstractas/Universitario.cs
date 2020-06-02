using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario() : base()
        { }
        /// <summary>
        /// Constructor con parametros de Universitario
        /// </summary>
        /// <param name="legajo">int legajo</param>
        /// <param name="nombre">string nombre</param>
        /// <param name="apellido">string apellido</param>
        /// <param name="dni">string dni</param>
        /// <param name="nacionalidad"> ENacionalidad nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Metodo abstracto que devuelve un string
        /// </summary>
        /// <returns>string</returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Metodo virtual que devuelve los datos de Universitario
        /// </summary>
        /// <returns>string con toda la informacion</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            sb.AppendLine("");
            sb.AppendLine($"LEGAJO : {this.legajo}");

            return sb.ToString();
        }
        /// <summary>
        /// Sobrescritura del metodo Equals para comparar dos Universitarios
        /// </summary>
        /// <param name="obj">Object obj</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            bool success = false;
            if(this.GetType() == obj.GetType() && (this.DNI == ((Universitario)obj).DNI || this.legajo == ((Universitario)obj).legajo))
            {
                success = true;
            }

            return success;
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Metodo que devuelve true si dos Universitarios son iguales
        /// </summary>
        /// <param name="pg1">Universitario pg1</param>
        /// <param name="pg2">Universitario pg2</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool success = false;
            if (pg1.Equals(pg2) == true)
            {
                success = true;
            }

            return success;
        }
        /// <summary>
        /// Metodo que devuelve true si dos Universitarios son distintos
        /// </summary>
        /// <param name="pg1">Universitario pg1</param>
        /// <param name="pg2">Universitario pg2</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}

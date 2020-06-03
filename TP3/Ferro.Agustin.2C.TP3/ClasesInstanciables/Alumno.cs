using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        public enum EEstadoCuenta
        {AlDia, Deudor, Becado}

        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno() : base()
        { }
        /// <summary>
        /// Constructor con parametros de alumno
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="nombre">string nombre</param>
        /// <param name="apellido">string apellido</param>
        /// <param name="dni">string dni</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        /// <param name="clasesQueToma">EClases clases que toma</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }
        /// <summary>
        /// Constructor con parametros de alumno
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="nombre">string nombre</param>
        /// <param name="apellido">string apellido</param>
        /// <param name="dni">string dni</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        /// <param name="clasesQueToma">EClases clases que toma</param>
        /// <param name="estadoCuenta">EEstadoCuenta estadoCuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id,nombre,apellido,dni,nacionalidad,clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Sobrecarga del metodo de Universitario que devuelve un string con los datos de Alumno
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.MostrarDatos()}");
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine($"CLASES QUE TOMA: {this.clasesQueToma}");

            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo de Universitario que devuelve un string en la clase que participa el Alumno
        /// </summary>
        /// <returns>string con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.clasesQueToma}";
        }
        /// <summary>
        /// Sobrecarga del metodo ToString que devuelve los datos de Alumno
        /// </summary>
        /// <returns>string con los datos de Alumno</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Operador que devuelve true si un Alumno participa en una EClases
        /// </summary>
        /// <param name="a">Alumno a</param>
        /// <param name="clases">EClases clases</param>
        /// <returns>bool</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clases)
        {
            bool success = false;

            if(a.estadoCuenta != EEstadoCuenta.Deudor && a.clasesQueToma == clases)
            {
                success = true;
            }

            return success;
        }
        /// <summary>
        /// Operador que devuelve true si un Alumno no participa en una EClases
        /// </summary>
        /// <param name="a">Alumno a</param>
        /// <param name="clases">EClases clases</param>
        /// <returns>bool</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clases)
        {
            bool success = false;

            if(a.clasesQueToma == clases)
            {
                success = true;
            }

            return success;
        }
        #endregion
    }
}

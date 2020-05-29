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
        public Alumno() : base()
        { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id,nombre,apellido,dni,nacionalidad,clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.MostrarDatos()}");
            sb.AppendLine($"Clases que toma: {this.clasesQueToma}");
            sb.AppendLine($"Estado de cuenta: {this.estadoCuenta}");

            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.clasesQueToma}";
        }
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion
        #region Operadores
        public static bool operator ==(Alumno a, Universidad.EClases clases)
        {
            bool success = false;

            if(a.estadoCuenta != EEstadoCuenta.Deudor && a.clasesQueToma == clases)
            {
                success = true;
            }

            return success;
        }
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

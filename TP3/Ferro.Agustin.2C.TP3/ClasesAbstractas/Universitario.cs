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
        public Universitario() : base()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            sb.AppendLine("");
            sb.AppendLine($"LEGAJO : {this.legajo}");

            return sb.ToString();
        }

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
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool success = false;
            if (pg1.Equals(pg2) == true)
            {
                success = true;
            }

            return success;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}

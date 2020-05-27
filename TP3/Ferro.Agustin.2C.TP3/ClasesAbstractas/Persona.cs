using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Persona
    {
        #region Atributos
        public enum ENacionalidad
        {Argentino, Extranjero}

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            { 
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        public Persona() { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,dni.ToString(),nacionalidad)
        { }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException();
            }
            else if((dato < 90000000 && nacionalidad == ENacionalidad.Extranjero) || (dato >= 90000000 && nacionalidad == ENacionalidad.Argentino))
            {
                throw new NacionalidadInvalidaException("La nacionalidad no coincide con el DNI");
            }
            else
            {
                return dato;
            }
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if ((dato.Length < 1 || dato.Length > 8) || (int.TryParse(dato, out int dni) == false))
            {
                throw new DniInvalidoException();
            }
            else
            {
                return dni;
            }
        }
        private string ValidarNombreApellido(string dato)
        {
            if ((Regex.IsMatch(dato, @"^[a-zA-Z]+$")) == true)
            {
                return dato;
            }
            else
            {
                return "";
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Nombre}");
            sb.AppendLine($"{this.Apellido}");
            sb.AppendLine($"{this.Nacionalidad}");
            sb.AppendLine($"{this.DNI}");

            return sb.ToString();
        }
        #endregion
    }
}

using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [XmlInclude(typeof(Universitario))]

    public abstract class Persona
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
        /// <summary>
        /// propiedad que establece o devuelve el string apellido
        /// </summary>
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
        /// <summary>
        /// propiedad que establece o devuelve un valor del enumerado ENacionalidad
        /// </summary>
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
        /// <summary>
        /// propiedad que establece o devuelve el int DNI
        /// </summary>
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
        /// <summary>
        /// propiedad que establece o devuelve el string nombre
        /// </summary>
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
        /// <summary>
        /// propiedad que valida que el string recibido sea un DNI
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// constructor por defecto de Persona
        /// </summary>
        public Persona() { }
        /// <summary>
        /// constructor de Persona con parametros
        /// </summary>
        /// <param name="nombre">string nombre</param>
        /// <param name="apellido">string apellido</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// constructor de Persona con parametros
        /// </summary>
        /// <param name="nombre">string nombre</param>
        /// <param name="apellido">string apellido</param>
        /// <param name="dni">int dni</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,dni.ToString(),nacionalidad)
        { }
        /// <summary>
        /// Constructor de persona con parametros
        /// </summary>
        /// <param name="nombre">string nombre</param>
        /// <param name="apellido">string apellido</param>
        /// <param name="dni">string dni</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Valida que la nacionalidad coincida con el DNI
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        /// <param name="dato">int dato</param>
        /// <returns>int dni</returns>
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
        /// <summary>
        /// Valida que el dni sea correcto
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        /// <param name="dato">string dato</param>
        /// <returns>el int DNI</returns>
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
        /// <summary>
        /// Valida que el nombre o apellido sean correctos
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>El nombre o apellido</returns>
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
        /// <summary>
        /// Sobrescritura del metodo ToString para que devuelva todos los datos de persona
        /// </summary>
        /// <returns>string con los datos de Persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"Nacionalidad: {this.Nacionalidad}");
            sb.AppendLine($"DNI: {this.DNI}");

            return sb.ToString();
        }
        #endregion
    }
}

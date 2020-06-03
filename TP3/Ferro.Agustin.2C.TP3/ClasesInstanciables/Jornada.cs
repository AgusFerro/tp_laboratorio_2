using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que retorna o setea el atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad que retorna o setea el atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad que retorna o setea el atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor privado de Jornada que inicializa la Lista de Alumnos
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor con parametros de Jornada
        /// </summary>
        /// <param name="clase">EClases clase</param>
        /// <param name="instructor">Profesor instructor</param>
        public Jornada(Universidad.EClases clase ,Profesor instructor) : this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }
        /// <summary>
        /// Metodo estatico que guarda los datos de una Jornada en un archivo
        /// </summary>
        /// <param name="jornada">Jornada jornada</param>
        /// <returns>bool</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            bool success = false;
            string path = @"C:\Users\agusf\Source\Repos\Ferro.Agustin.2C.TP3\Jornada.txt";
            txt.Guardar(path, jornada.ToString());
            success = true;
            return success;
        }
        /// <summary>
        /// Metodo estatico que lee un archivo y devuelve un string con los datos de una jornada
        /// </summary>
        /// <returns>string con los datos</returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            string dato;
            string path = @"C:\Users\agusf\Source\Repos\Ferro.Agustin.2C.TP3\Jornada.txt";
            txt.Leer(path, out dato);
            return dato;
        }
        /// <summary>
        /// Sobrecarga del metodo ToString que devuelve un string con los datos de Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendLine($"CLASE DE:{this.Clase} POR {this.Instructor.ToString()}");
            foreach(Alumno alum in this.Alumnos)
            {
                sb.AppendLine(alum.ToString());
            }
            sb.AppendLine("<-------------------------------------------------------------->");

            return sb.ToString();
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Operador que devuelve true si un objeto Alumno esta adentro de la Lista de Alumnos de Jornada
        /// </summary>
        /// <param name="j">Jornada j</param>
        /// <param name="a">Alumno a</param>
        /// <returns>bool</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool success = false;
            
            foreach(Alumno alumno in j.Alumnos)
            {
                if(alumno == a)
                {
                    success = true;
                }
            }

            return success;
        }
        /// <summary>
        /// Operador que devuelve true si un objeto Alumno no esta adentro de la Lista de Alumnos de Jornada
        /// </summary>
        /// <param name="j">Jornada j</param>
        /// <param name="a">Alumno a</param>
        /// <returns>bool</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Operador que agrega un objeto Alumno en la Lista del Alumnos de Jornada
        /// </summary>
        /// <param name="j">Jornada j</param>
        /// <param name="a">Alumno a</param>
        /// <returns>objeto Jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.Alumnos.Add(a);
            }

            return j;
        }

        #endregion
    }
}

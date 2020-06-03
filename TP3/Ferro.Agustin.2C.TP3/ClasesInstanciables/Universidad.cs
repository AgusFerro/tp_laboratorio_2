using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos
        public enum EClases
        {Programacion,Laboratorio,Legislacion,SPD}
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que retorna o setea una Lista de Alumnos
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
        /// Propiedad que retorna o setea una Lista de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad que retorna o setea una Lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Propiedad que retorna o setea un elemento en la Lista de Jornadas
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get
            {
                if (index >= 0 && index < this.Jornadas.Count)
                {
                    return this.Jornadas[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index < this.Jornadas.Count)
                {
                    this.Jornadas[index] = value;
                }
                else
                {
                    this.Jornadas.Add(value);
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defecto de Universidad
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        /// <summary>
        /// Metodo estatico que devuelve los metodos de una Universidad
        /// </summary>
        /// <param name="uni">Universidad uni</param>
        /// <returns>string con los datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo ToString que devuelve los datos de Universidad
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Metodo estatico que guarda en un XML los datos de Univesidad
        /// </summary>
        /// <param name="uni">Universidad uni</param>
        /// <returns>bool</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            bool success = false;
            string path = @"C:\Users\agusf\Source\Repos\Ferro.Agustin.2C.TP3\Universidad.xml";
            success = xml.Guardar(path, uni);
            return success;
        }
        /// <summary>
        /// Metodo estatico que lee un XML y devuelve un objeto Universidad
        /// </summary>
        /// <returns>objeto Universidad</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad u = new Universidad();
            string path = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            xml.Leer(path, out u);
            return u;
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Operador que devuelve true si un objeto Alumno esta en la Lista de Alumnos de Universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool success = false;
            foreach(Alumno alumno in g.Alumnos)
            {
                if(alumno == a)
                {
                    success = true;
                }
            }
            return success;
        }
        /// <summary>
        /// Operador que devuelve true si un objeto Profesor esta en la Lista de Profesores de Universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool success = false;
            foreach(Profesor profesor in g.Instructores)
            {
                if(profesor == i)
                {
                    success = true;
                }
            }
            return success;
        }
        /// <summary>
        /// Operador que devuelve un Profesor que pueda dar la clase recibida en el parametro
        /// </summary>
        /// <param name="u">Universidad u</param>
        /// <param name="clase">EClases clase</param>
        /// <returns>objeto Profesor</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor p;
            foreach(Profesor profesor in u.Instructores)
            {
                if(profesor == clase)
                {
                    p = profesor;
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Operador que devuelve true si un objeto Alumno no esta en la Lista de Alumnos de Universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Operador que devuelve true si un objeto Profesor esta en la Lista de Profesores de Universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Operador que devuelve el primer Profesor que no pueda dar la clase recibida por parametro
        /// </summary>
        /// <param name="u">Universidad u</param>
        /// <param name="clase">EClases clase</param>
        /// <returns>objeto Profesor</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor p = null;
            foreach(Profesor profesor in u.Instructores)
            {
                if(profesor != clase)
                {
                    p = profesor;
                    break;
                }
            }
            return p;
        }

        /// <summary>
        /// Operador que agrega un objeto Alumno en la Lista de Alumnos de Universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>objeto Universidad</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g == a)
            {
                throw new AlumnoRepetidoException();
            }
            else 
            {
                g.Alumnos.Add(a);
            }
            return g;
        }
        /// <summary>
        /// Operador que agrega un objeto Profesor en la Lista de Profesores de Universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>objeto Universidad</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if(g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }
        /// <summary>
        /// Operador que agrega un objeto Jornada en la Lista de Jornadas de Universidad si hay un Profesor que pueda dar la clase recibida en el parametro
        /// </summary>
        /// <param name="u">Universidad u</param>
        /// <param name="clase">EClases clase</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada j = new Jornada(clase, u == clase);
            foreach(Alumno alumno in u.Alumnos)
            {
                if (alumno == clase)
                {
                    j += alumno;
                }
            }
            u.Jornadas.Add(j);

            return u;
        }

        #endregion
    }
}

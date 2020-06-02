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
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            bool success = false;
            string path = @"C:\Users\agusf\Source\Repos\Ferro.Agustin.2C.TP3\Universidad.xml";
            success = xml.Guardar(path, uni);
            return success;
        }
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
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
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
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if(g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }
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

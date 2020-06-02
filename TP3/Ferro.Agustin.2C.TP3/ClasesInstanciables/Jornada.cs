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
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase ,Profesor instructor) : this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            bool success = false;
            //string path = "Jornada.txt";
            string path = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            txt.Guardar(path, jornada.ToString());
            success = true;
            return success;
        }
        public static string Leer()
        {
            Texto txt = new Texto();
            string dato;
            //string path = "Jornada.txt";
            string path = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            txt.Leer(path, out dato);
            return dato;
        }
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
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
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

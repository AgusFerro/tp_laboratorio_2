using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor estatico de Profesor que inicializa el atributo estatico random
        /// </summary>
        static Profesor() 
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor por defecto privado de Profesor
        /// </summary>
        private Profesor() : base()
        { }
        /// <summary>
        /// Constructor con parametros de Profesor
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="nombre">string nombre</param>
        /// <param name="apellido">string apellido</param>
        /// <param name="dni">string dni</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        { 
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        /// <summary>
        /// Metodo que carga dos veces el atributo clasesDelDia de forma aleatoria
        /// </summary>
        private void _randomClases()
        {
            for(int i = 0; i < 2; i++)
            {
                int caso = random.Next(1, 4);

                switch (caso)
                {
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 4:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            } 
        }
        /// <summary>
        /// Sobrecarga del metodo de Universitario que devuelve un string con los datos de Profesor
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.MostrarDatos()}");
            sb.AppendLine($"CLASES DEL DIA:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine($"{clase}");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo de Universitario que devuelve un string con las clases que da el Profesor
        /// </summary>
        /// <returns>string con las clases que da</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine($"{clase.ToString()}");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sonbrecarga del metodo ToString que devuelve un string de los datos de Profesor
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Operador que devuelve true si un profesor da esa clase
        /// </summary>
        /// <param name="i">Profesor i</param>
        /// <param name="clase">EClases clase</param>
        /// <returns>boll</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool success = false;

            foreach (Universidad.EClases clases in i.clasesDelDia)
            {
               if(clase == clases)
                {
                    success = true;
                }
            }

            return success;
        }
        /// <summary>
        /// Devuelve true si un profesor no da esa clase
        /// </summary>
        /// <param name="i">Profesor i</param>
        /// <param name="clase">EClases clase</param>
        /// <returns>bool</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}

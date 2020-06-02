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
        static Profesor() 
        {
            random = new Random();
        }
        private Profesor() : base()
        { }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        { 
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
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
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion
        #region Operadores
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
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}

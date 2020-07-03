using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion
        #region Propiedades
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor de Correo que incializa sus dos atributos
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        /// <summary>
        /// Metodo que devuelve la informacion de cada Paquete dentro de elemento
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Paquete p in Paquetes)
            {
                sb.AppendLine(String.Format("{0} para {1} ({2})",p.TrackingID,p.DireccionEntrega,p.Estado.ToString()));
            }
            return sb.ToString();
        }
        /// <summary>
        /// Metodo que aborta todos los hilos o subprocesos de Correo
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Operador que agrega un Paquete a la lista de Correo y ejecuta un subproceso
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete paquete in c.paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIDRepetidoException("El paquete ya existe");
                }
            }

            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }
        #endregion
    }
}

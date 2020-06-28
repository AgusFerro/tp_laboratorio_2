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
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        public string MostrarDatos(List<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Paquete p in this.paquetes)
            {
                sb.Append(String.Format("{0} para {1} ({2})",p.TrackingID,p.DireccionEntrega,p.Estado.ToString()));
            }
            return sb.ToString();
        }
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

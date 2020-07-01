using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #region Atributos
        public enum EEstado
        {Ingresado,EnViaje,Entregado }
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion
        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set 
            {
                this.trackingID = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor de Paquete con parametros.
        /// </summary>
        /// <param name="direccionEntrega"> string direccion del Paquete</param>
        /// <param name="trackingID">string ID del Paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        /// <summary>
        /// Metodo que cada 4 segundos pasa al siguiente Estado del Paquete hasta
        /// que el Paquete este entregado. Al final, el Paquete se guarda en la tabla.
        /// </summary>
        public void MockCicloDeVida()
        {
            for(int i = 0; i < 4; i++)
            {
                if (this.estado == EEstado.Entregado)
                {
                    break;
                }
                else
                {
                    this.estado = (EEstado)i;
                    InformarEstado.Invoke(this,null);
                    Thread.Sleep(4000);
                }
            }
            PaqueteDAO.Insertar(this);
        }
        /// <summary>
        /// Metodo que devuelve un string con la informacion del elemento
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}",TrackingID, DireccionEntrega);
        }
        /// <summary>
        /// Metodo sobrescrito que devuelve la informacion del Paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Operador que devuelve true si dos Paquetes son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool success = false;
            if(p1.trackingID == p2.trackingID)
            {
                success = true;
            }
            return success;
        }
        /// <summary>
        /// Operador que devuelve true si dos Paquetes son distintos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        /// <summary>
        /// Evento que informa el Estado de los Paquetes
        /// </summary>
        public event DelegadoEstado InformarEstado;
    }
}

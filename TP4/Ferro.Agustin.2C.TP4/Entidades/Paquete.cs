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
        #region Atributos
        public delegate void DelegadoEstado();
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
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        public void MockCicloDeVida()
        {
            for(int i = 1; i < 4; i++)
            {
                if (this.estado == EEstado.Entregado)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(4000);
                    this.estado = (EEstado)i;
                    InformarEstado.Invoke();
                }
            }
            PaqueteDAO.Insertar(this);
        }
        public string MostrarDatos(Paquete p)
        {
            return String.Format("{0} para {1}",p.trackingID, p.direccionEntrega);
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion
        #region Operadores
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool success = false;
            if(p1.trackingID == p2.trackingID)
            {
                success = true;
            }
            return success;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
        public event DelegadoEstado InformarEstado;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Atributos
        private Correo correo;
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor de FrmPpal sin parametros que instancia el atributo Correo
        /// </summary>
        public FrmPpal()
        {
            correo = new Correo();
            InitializeComponent();
        }
        /// <summary>
        /// Evento Load del formulario que indica que Propiedades se van a mostrar en las ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_Load(object sender, EventArgs e)
        {
            lstEstadoEntregado.DisplayMember = "TrackingID";
            lstEstadoEnViaje.DisplayMember = "TrackingID";
            lstEstadoIngresado.DisplayMember = "TrackingID";
        }
        /// <summary>
        /// Metodo que actualiza las ListBox del formulario
        /// </summary>
        private void ActualizarEstado()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach(Paquete paquete in this.correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }
        /// <summary>
        /// Metodo que llama a ActualizarEstado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }
        }
        /// <summary>
        /// Evento que agrega un nuevo Paquete a la lista de Correo, asocia el Evento InformarEstado del paquete
        /// al manejador paq_InformaEstado, y ademas, asocia un Evento de errores DAO al manejador ErrorBase para informar
        /// si se produjo un error en las sentencias de SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

            try
            {
                paquete.InformarEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
                PaqueteDAO.InformarException += new PaqueteDAO.DelegadoBase(ErrorBase);
                this.correo += paquete;
            }
            catch (TrackingIDRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Paquete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Metodo que informa que si se produjo un error en el metodo de PaqueteDAO
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="e"></param>
        private void ErrorBase(string mensaje, Exception e)
        {
            MessageBox.Show(mensaje, e.GetType().ToString());
        }
        /// <summary>
        /// Metodo que escribe en el RichTextBox del formulario la informacion del elemento, luego lo guarda
        /// en un archivo plano
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al guardar en archivo");
                }
            }
        }
        /// <summary>
        /// Evento que escribe en el RichTextBox la informacion del paquete entregado seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// Evento que escribe en el RichTextBox la informacion de todos los Paquetes del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Evento del formulario que cierra los subprocesos de Correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
        #endregion
    }
}

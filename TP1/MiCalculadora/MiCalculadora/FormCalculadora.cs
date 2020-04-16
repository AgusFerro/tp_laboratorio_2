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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// llama al metodo Operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// metodo que llama al metodo estatico Operar de calculadora
        /// </summary>
        /// <param name="numero1">objeto Numero 1</param>
        /// <param name="numero2">objeto Numero 2</param>
        /// <param name="operador"> operador </param>
        /// <returns> el retorno del metodo al que se invoca </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            // para que funcione con numeros con coma, usar la ',' y no el '.'
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            resultado = Calculadora.Operar(num1, num2, operador);
            return resultado;
        }
        /// <summary>
        /// llama al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// deja los textos vacios
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }

        /// <summary>
        /// cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// llama a la funcion DecimalBinario del objeto tipo Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero binario = new Numero(lblResultado.Text);
            lblResultado.Text = binario.DecimalBinario(lblResultado.Text);
        }

        /// <summary>
        /// llama a la funcion BinarioDecimal del objeto tipo Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero deci = new Numero(lblResultado.Text);
            lblResultado.Text = deci.BinarioDecimal(lblResultado.Text);
        }
    }
}

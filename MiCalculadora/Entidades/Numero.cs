using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos

        private double numero;

        #endregion

        #region Propiedades

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #endregion

        #region Metodos
        public Numero() { }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        public string BinarioDecimal(string binario)
        {
            double numero = 0;
            int bin;
            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(binario[binario.Length - i - 1].ToString(), out bin))
                {
                    numero += bin * Math.Pow(2, i);
                }
                else
                {
                    return "";
                }
            }
            return numero.ToString();
        }
        public string DecimalBinario(string numero)
        { }
        public string DecimalBinario(double numero)
        {
            string binario = "";

            do
            {
                if ((numero % 2) == 0)
                    binario = "0" + binario;
                else
                    binario = "1" + binario;
                numero = (int)(numero / 2);
            } while (numero > 0);

            return binario;
        }

        private double ValidarNumero(string strNumero)
        {
            double num = -1, aux;

            bool succes = double.TryParse(strNumero, out aux);
            if (succes == true)
            {
                num = aux;
            }
            return num;
        }

        #endregion

        #region Operadores

        public static Numero operator +(Numero num1, Numero num2)
        {
            Numero aux = new Numero(num1.numero + num2.numero);
            return aux;
        }
        public static Numero operator -(Numero num1, Numero num2)
        {
            Numero aux = new Numero(num1.numero - num2.numero);
            return aux;
        }
        public static Numero operator *(Numero num1, Numero num2)
        {
            Numero aux = new Numero(num1.numero * num2.numero);
            return aux;
        }
        public static Numero operator /(Numero num1, Numero num2)
        {
            if () { }
            Numero aux = new Numero(num1.numero / num2.numero);
            return aux;
        }

        #endregion
    }
}

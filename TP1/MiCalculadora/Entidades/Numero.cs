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
        /// <summary>
        /// 
        /// </summary>
        public Numero() :this(0)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) :this(numero + "")
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double num = 0, aux;

            bool succes = double.TryParse(strNumero, out aux);
            if (succes == true)
            {
                num = aux;
            }
            return num;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
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
                    return "Valor Invalido";
                }
            }
            return numero.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double numeroDecimal;
            bool succes;
            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] < '0' || numero[i] > '9')
                    return "Valor invalido";
            }
            succes = double.TryParse(numero, out numeroDecimal);
            if (succes == true)
            {
                return DecimalBinario(numeroDecimal);
            }
            else 
            {
                return "Valor invalido";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
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


        #endregion

        #region Operadores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        /// <summary>
        /// sobrecarga del operador *
        /// </summary>
        /// <param name="num1"> objeto Numero 1</param>
        /// <param name="num2"> objeto Numero 2</param>
        /// <returns> resultado de la operacion</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        /// <summary>
        /// sobrecarga del operador /
        /// </summary>
        /// <param name="num1"> objeto Numero 1</param>
        /// <param name="num2"> objeto Numero 2</param>
        /// <returns> resultado de la operacion </returns>
        public static double operator /(Numero num1, Numero num2)
        {
            if(num1.numero == 0 || num2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return num1.numero / num2.numero;
            }
        }

        #endregion
    }
}

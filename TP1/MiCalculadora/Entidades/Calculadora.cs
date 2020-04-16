using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// valida el operador
        /// </summary>
        /// <param name="operador"></param>
        /// <returns> devuele el operador recibido o un +</returns>
        private static string ValidarOperador(string operador)
        {
            if(operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }

        /// <summary>
        /// resuelve el calculo
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="operador"></param>
        /// <returns>el resultado del calculo</returns>
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double retorno = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = n1 + n2;
                    break;
                case "-":
                    retorno = n1 - n2;
                    break;
                case "*":
                    retorno = n1 * n2;
                    break;
                case "/":
                    retorno = n1 / n2;
                    break;
            }

            return retorno;
        }
    }
}

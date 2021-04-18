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
        /// Opera num1 con num2, el tipo de operacion lo define el string operador
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operacion que se haya realizado o el resultado de la suma (default)</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            char charOperador;
            double resultado = 0;
            if (!string.IsNullOrEmpty(operador))
            {
                char.TryParse(operador, out charOperador);
                operador = ValidarOperador(charOperador);
                switch (operador)
                {
                    case "+":
                        {
                            resultado = num1 + num2;
                            break;
                        }
                    case "-":
                        {
                            resultado = num1 - num2;
                            break;
                        }
                    case "*":
                        {
                            resultado = num1 * num2;
                            break;
                        }
                    case "/":
                        {
                            resultado = num1 / num2;
                            break;
                        }
                    default:
                        {
                            resultado = num1 + num2;
                            break;
                        }
                }
            }
            return resultado;
        }
        
        /// <summary>
        /// Valida que el operador sea + , - , * o /
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>El operador como string o "+" (default)</returns>
        private static string ValidarOperador(char operador)
        {
            string rtn= "+";
            string auxArray = "+-*/";
            foreach(char aux in auxArray)
            {
                if(operador == aux)
                {
                    rtn = $"{operador}";
                    break;
                }
            }
            return rtn;
        }
    }
}

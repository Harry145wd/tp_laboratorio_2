using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        //Atributes

        private double numero;

        //Properties
        /// <summary>
        /// Propiedad que setea el atributo numero(double).
        /// </summary>
        /// <remarks>
        /// Debe recibir un string
        /// </remarks>
        public string SetNumero
        { 
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        //Constructors
        /// <summary>
        /// Constructor sin parametros, establece el atriburto numero(double) en 0.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor Parametrizado establece el atriburto numero(double) con el valor recibido por parametro.
        /// </summary>
        /// <param name="numero">
        /// Valor que se establecera en el atributo de intancia numero(double).
        /// </param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /* Numero() :this(0.0)
         {
         }
        No se si esta mal crear el constructor por defecto como sobrecarga de otro constructor con parametros
        pero en caso de que no estuviera mal, asi lo hubiese hecho
        */

        /// <summary>
        /// Constructor Parametrizado establece el atriburto numero(double) con el valor recibido por parametro.
        /// </summary>
        /// <param name="strNumero">
        /// Valor que se establecera en el atributo de intancia numero(double).
        /// </param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        //Methods

        /// <summary>
        /// Valida que el string recibido sea un numero y lo devuelve como double.
        /// </summary>
        /// <param name="strNumero">parametro a ser evaluado.</param>
        /// <returns>Valor con coma flotante o 0 en caso de no poder realizar la conversion.</returns>
        public static double ValidarNumero(string strNumero)
        {
            double rtn;
            strNumero.Trim();
            /*
            if(System.Threading.Thread.CurrentThread.CurrentCulture.Name == "es-AR")
            {
                //strNumero = strNumero.Replace('.', ',');
            }  
            Las lineas anteriores sirven para que si el usuario quiere usar un '.' como coma, lo transforme a una ',' 
            (en caso de estar usando Windows con el idioma español de argentina)
            pero no lo termine usando pq me parecia muy especifico y en caso de que el tp se abra desde una pc con windows en ingles
            si uso el replace no va ahcer ninguna de las operaciones con numeros con coma. 
            Es bastante complicado encontrarle la vuelta asi que lo dejo a criterio de quien vea el tp,
            no se me ocurrio otra forma de validar
            */
            double.TryParse(strNumero, out rtn);
            return rtn;
        }

        /// <summary>
        /// Evalua un string para verificar que todos sus caracteres sean unos y/o ceros.
        /// </summary>
        /// <param name="strBinario">String a ser evaluado.</param>
        /// <returns>True si el string es binario, false si el string es nulo o contiene un caracter diferente a 1 y a 0.</returns>
        private static bool EsBinario(string strBinario)
        {
            bool ret = true;
            if (!string.IsNullOrWhiteSpace(strBinario))
            {
                foreach (char aux in strBinario)
                {
                    if (aux != '1' && aux != '0')
                    {
                        ret = false;
                        break;
                    }
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// Verifica que el string ingresado por parametros sea binario y en caso de serlo, lo transforma a decimal.
        /// </summary>
        /// <param name="strBinario">String a ser evaluado y convertido.</param>
        /// <returns>Numero decimal resultado de la conversion en forma de string o "Valor invalido" si no pudo realizar la conversion.</returns>
        public static string BinarioDecimal(string strBinario)
        {
            char[] auxCadena;
            int multiplier;
            int acumulador=0;
            string ret = "Valor Invalido";
            if (!string.IsNullOrWhiteSpace(strBinario) && EsBinario(strBinario))
            {
                auxCadena = strBinario.ToCharArray();
                multiplier= 1;
                for(int i = strBinario.Length - 1; i >=0; i--)
                {
                    acumulador+= int.Parse($"{auxCadena[i]}")*multiplier;
                    multiplier *= 2;
                }
                ret = $"{acumulador}";
            }
            return ret;
        }

        /// <summary>
        /// Convierte un numero decimal en binario. 
        /// </summary>
        /// <param name="numero">Numero decimal que sera casteado a entero absoluto para calcular el binario.</param>
        /// <returns>Numero binario en forma de string.</returns>
        public static string DecimalBinario(double numero)
        {
            string binaryAux = string.Empty;
            string binaryNumber = string.Empty;
            char[] binaryCharAux;
            int decimalNumber = (int)Math.Abs(numero); 
            while (decimalNumber >= 2)
            {
                if (decimalNumber % 2 == 0)
                {
                    binaryAux += "0";
                }
                else
                {
                    binaryAux += "1";
                }
                decimalNumber /= 2;
            }
            binaryAux += "1";
            binaryCharAux = binaryAux.ToCharArray();
            for (int i = binaryAux.Length - 1; i > -1; i--)
            {
                binaryNumber += binaryCharAux[i];
            }
            return binaryNumber;
        }

        /// <summary>
        /// Convierte un numero decimal en binario. 
        /// </summary>
        /// <param name="strNumero">Numero decimal en forma de string que sera casteado a entero absoluto para calcular el binario.</param>
        /// <returns>Numero binario en forma de string.</returns>
        public static string DecimalBinario(string strNumero)
        {
            double numero;
            string rtn = "Valor Invalido";
            if(!string.IsNullOrEmpty(strNumero) && double.TryParse(strNumero, out numero))
            {
                rtn = DecimalBinario(numero);
            }
            return rtn;
        }


        //Operators
        /// <summary>
        /// Suma los atributos numero(double) de dos objetos de clase Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Suma de los dos objetos.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta los atributos numero(double) de dos objetos de clase Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resta de los dos objetos.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica los atributos numero(double) de dos objetos de clase Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Multiplicacion de los dos objetos.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide los atributos numero(double) de dos objetos de clase Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Division de los dos objetos o double.MinValue si n2 es 0 </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double ret;
            if(n2.numero==0)
            {
                ret = double.MinValue;
            }
            else
            {
                ret= n1.numero / n2.numero;
            }
            return ret;
        }

    }
}

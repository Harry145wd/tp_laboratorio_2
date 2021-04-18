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
        public string SetNumero
        { 
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        //Constructors
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
       /* Numero() :this(0.0)
        {
        }
       */
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        //Methods
        public static double ValidarNumero(string strNumero)
        {
            double rtn;
            double.TryParse(strNumero, out rtn);
            return rtn;
        }

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
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
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

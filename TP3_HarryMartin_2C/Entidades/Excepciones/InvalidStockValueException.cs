using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InvalidStockValueException: Exception
    {
        #region Constructors
        public InvalidStockValueException():base("El valor de Stock proporcionado es invalido, por favor verifique que este no sea negativo")
        {
            
        }
        public InvalidStockValueException(string message):base(message)
        {

        }
        public InvalidStockValueException(string message, Exception innerException) : base(message, innerException)
        {

        }
        #endregion
    }
}

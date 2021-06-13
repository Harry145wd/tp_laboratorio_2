using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NotEnoughMaterialsException :Exception
    {
        #region Constructors
        public NotEnoughMaterialsException() : base("El valor de Stock proporcionado es invalido, por favor verifique que este no sea negativo")
        {

        }
        public NotEnoughMaterialsException(string message) : base(message)
        {

        }
        public NotEnoughMaterialsException(string message, Exception innerException) : base(message, innerException)
        {

        }
        #endregion
    }
}

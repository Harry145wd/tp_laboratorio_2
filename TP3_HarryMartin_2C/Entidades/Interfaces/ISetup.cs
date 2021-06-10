using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  interface ISetup<T> where T: Enum
    {
        string LblSetup(T enumEntrada);
        Enum EnumSetup(T enumEntrada);
    }
}

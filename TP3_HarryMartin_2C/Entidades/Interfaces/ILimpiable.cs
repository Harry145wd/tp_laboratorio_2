using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ILimpiable
    {
        bool EstaLimpio { get; set; }

        void Limpiar();
    }
}

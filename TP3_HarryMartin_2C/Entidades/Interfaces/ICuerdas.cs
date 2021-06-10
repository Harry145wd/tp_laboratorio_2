using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface ICuerdas
    {       
        bool EstaEncordado { get; set; }

        void Encordar();
    }
}

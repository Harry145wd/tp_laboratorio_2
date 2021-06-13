using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IListaDeInstrumentos
    {
        List<Instrumento> ListaDeInstrumentos { get; set; }
        bool ValidarPasaje(Instrumento instrumento);
        void PasarA<T>(T receptora, Instrumento instrumento) where T : IListaDeInstrumentos, IProceso<Instrumento>;
    }
}

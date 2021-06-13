using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Barnizadora : IListaDeInstrumentos, IProceso<Instrumento>
    {
        #region Atributes
        private List<Instrumento> instrumentos;
        #endregion

        #region Properties
        public List<Instrumento> ListaDeInstrumentos
        { 
            get { return this.instrumentos; }
            set { this.instrumentos = value; }
        }
        #endregion

        #region Constructors
        public Barnizadora()
        {
            this.ListaDeInstrumentos = new List<Instrumento>();
        }


        #endregion

        #region Methods
        public void Procesar(Instrumento item)
        {
            IBarnizable instrumento = (IBarnizable)item;
            instrumento.Barnizar();
        }

        public bool ValidarPasaje(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is IBarnizable)
            {
                ret = true;
            }
            else
            {
                throw new Exception("Este instrumento no puede ser barnizado con la Barnizadora");
            }
            return ret;
        }

        public void PasarA<T>(T receptora, Instrumento instrumento) where T : IListaDeInstrumentos, IProceso<Instrumento>
        {
            if (receptora.ValidarPasaje(instrumento))
            {
                receptora.Procesar(instrumento);
                receptora.ListaDeInstrumentos.Add(instrumento);
                this.ListaDeInstrumentos.Remove(instrumento);
            }
        }
        #endregion

        #region Operators
        #endregion
    }
}

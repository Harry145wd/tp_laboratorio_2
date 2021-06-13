using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Limpiadora : IListaDeInstrumentos, IProceso<Instrumento>
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
        public Limpiadora()
        {
            this.ListaDeInstrumentos = new List<Instrumento>();
        }
        #endregion

        #region Methods
        public void Procesar(Instrumento item)
        {
            ILimpiable instrumento = (ILimpiable)item;
            instrumento.Limpiar();
        }

        public bool ValidarPasaje(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is ILimpiable)
            {
                ret = true;
            }
            else
            {
                throw new Exception("Este instrumento no se puede ser limpiado con la Limpiadora");
            }
            return ret;
        }

        public void PasarA<T>(T receptora, Instrumento instrumento)where T : IListaDeInstrumentos, IProceso<Instrumento>
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

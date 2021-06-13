using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Afinadora: IListaDeInstrumentos, IProceso<Instrumento>
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
        public Afinadora()
        {
            this.ListaDeInstrumentos = new List<Instrumento>();
        }


        #endregion

        #region Methods
        public void Procesar(Instrumento item)
        {
            IAfinable instrumento = (IAfinable)item;
            instrumento.Afinar();
        }

        public bool ValidarPasaje(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is IAfinable)
            {
                if (instrumento is ICuerdas)
                {
                    ICuerdas iCuerdas = (ICuerdas)instrumento;
                    if (iCuerdas.EstaEncordado)
                    {
                        ret = true;
                    }
                    else
                    {
                        throw new Exception("El instrumento no se puede afinar ya que no tiene cuerdas");
                    }
                }
                if (instrumento is ILimpiable)
                {
                    ILimpiable ilimpiable = (ILimpiable)instrumento;
                    if (ilimpiable.EstaLimpio)
                    {
                        ret = true;
                    }
                    else
                    {
                        throw new Exception("El instrumento no se puede afinar ya que no fue limpiado");
                    }
                }

                ret = true;
            }
            else
            {
                throw new Exception("Este instrumento no se puede afinar con la Afinadora");
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

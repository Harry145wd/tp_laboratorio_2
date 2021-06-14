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
        /// <summary>
        /// Inicializa una lista de Instrumentos vacia
        /// </summary>
        public Limpiadora()
        {
            this.ListaDeInstrumentos = new List<Instrumento>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Limpia el Instrumento especificado por parametro
        /// </summary>
        /// <param name="item"></param>
        public void Procesar(Instrumento item)
        {
            ILimpiable instrumento = (ILimpiable)item;
            instrumento.Limpiar();
        }
        /// <summary>
        /// Valida que el instrumento por parametro pueda agregarse a la lista de la Limpiadora
        /// </summary>
        /// <param name="instrumento"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Pasa el Instrumento especificado de la lista de la Limpiadora a la lista especificada por parametro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="receptora"></param>
        /// <param name="instrumento"></param>
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

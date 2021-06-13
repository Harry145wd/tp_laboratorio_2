using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Afinadora
    {
        #region Atributes
        private List<Instrumento> instrumentos;
        #endregion

        #region Properties
        public List<Instrumento> Instrumentos
        {
            get { return this.instrumentos; }
            set { this.instrumentos = value; }
        }
        #endregion

        #region Constructors
        public Afinadora()
        {
            this.Instrumentos = new List<Instrumento>();
        }
        #endregion

        #region Methods
        #endregion

        #region Operators
        #endregion
    }
}

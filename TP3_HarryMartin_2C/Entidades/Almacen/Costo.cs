using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Costo
    {
        #region Atributes
        eTipoInstrumento tipoInstrumento;
        eMaterial material;
        int costo;
        #endregion

        #region Properties
        public eTipoInstrumento TipoInstrumento
        {
            get { return this.tipoInstrumento; }
            set { this.tipoInstrumento = value; }
        }
        public eMaterial Material
        {
            get { return this.material; }
            set { this.material = value; }
        }
        public int CostoDeMaterial
        {
            get { return this.costo; }
            set 
            {
                if (value > -1)
                {
                    this.costo = value;
                }
                else
                {
                    this.costo = 0;
                }
            }
        }
        #endregion

        #region Constructors
        public Costo(eTipoInstrumento tipo, eMaterial material, int costo)
        {
            this.TipoInstrumento = tipo;
            this.Material = material;
            this.CostoDeMaterial = costo;
        }
        #endregion

        #region Methods
        #endregion

        #region Operators
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Stock
    {
        #region Atributes
        private eMaterial material;
        private int cantidad;
        #endregion

        #region Properties

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public eMaterial Material
        {
            get { return material; }
            set { material = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Inicializa el Material del Stock con el valor por parametro
        /// </summary>
        /// <param name="material"></param>
        public Stock(eMaterial material)
        {
            this.Material = material;
        }
        /// <summary>
        /// Inicializa Material y Cantidad inicial del Stock con valores por parametro
        /// </summary>
        /// <param name="material"></param>
        /// <param name="cantidad"></param>
        public Stock(eMaterial material, int cantidad) : this(material)
        {
            this.Cantidad = cantidad;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite Re-Stockear un objeto de tipo stock
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public bool ReStock(int cantidad)
        {
            bool ret = false;
            if (cantidad >0)
            {
                this.Cantidad += cantidad;
                ret = true;
            }
            else
            {
                throw new InvalidStockValueException("El valor de Re-Stock es 0 o menor");
            }
            return ret;
        }
        /// <summary>
        /// Permite De-Stockear un objeto de tipo stock
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public bool DeStock(int cantidad)
        {
            bool ret = false;
            if (cantidad <= this.Cantidad)
            {
                this.Cantidad -= cantidad;
                ret = true;
            }
            else
            {
                throw new InvalidStockValueException("No hay suficiente stock");
            }
            return ret;
        }
        /// <summary>
        /// Muestra la cantidad de un material
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Cantidad de {this.Material}: {this.Cantidad}";
        }
        #endregion

        #region Operators
        public static bool operator ==(Stock s1, Stock s2)
        {
            return (s1.Material == s2.Material);
        }
        public static bool operator !=(Stock s1, Stock s2)
        {
            return !(s1 == s2);
        }
        public static bool operator ==(Stock s, eMaterial m)
        {
            return (s.Material == m);
        }
        public static bool operator !=(Stock s, eMaterial m)
        {
            return !(s == m);
        }

        #endregion

    }
}

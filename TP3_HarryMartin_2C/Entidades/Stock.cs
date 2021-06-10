using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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
        public Stock(eMaterial material)
        {
            this.Material = material;
        }
        public Stock(eMaterial material, int cantidad) : this(material)
        {
            this.Cantidad = cantidad;
        }
        #endregion

        #region Methods
        public bool ReStock(int cantidad)
        {
            bool ret = false;
            if (cantidad > -1)
            {
                this.Cantidad += cantidad;
                ret = true;
            }
            return ret;
        }
        public bool DeStock(int cantidad)
        {
            bool ret = false;
            if (cantidad <= this.Cantidad)
            {
                this.Cantidad -= cantidad;
                ret = true;
            }
            return ret;
        }
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

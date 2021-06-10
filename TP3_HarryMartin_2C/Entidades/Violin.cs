using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Violin : Instrumento , ICuerdas, IAfinable, ISetup<eTipoInstrumento>
    {
        #region Atributes
        
        private eModelosViolin modelo;
        private bool estaEncordado;
        private bool estaAfinado;

        #endregion

        #region Enums
        public enum eModelosViolin
        {
            unCuarto,
            dosCuartos,
            tresCuartos,
            cuatroCuartos
        }
        #endregion

        #region Properties
       
        public eModelosViolin Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public bool EstaEncordado 
        {
            get { return this.estaEncordado; }
            set { this.estaEncordado = value; }
        }
        public bool EstaAfinado
        {
            get { return this.estaAfinado; }
            set { this.estaAfinado = value; }
        }
        public bool Terminado
        {
            get
            {
                return (estaEncordado && estaAfinado);
            }
        }
        #endregion

        #region Constructors
        static Violin()
        {
            Violin.tipoInstrumento = eTipoInstrumento.Violin;
        }
        public Violin()
        {

        }
        public Violin(eModelosViolin modelo) :base()
        {
            this.Modelo = modelo;
        }
        public Violin(string luthier, DateTime fecha, eModelosViolin modelo) : base(luthier, fecha)
        {
            this.Modelo = modelo;
        }
        #endregion

        #region Methods
        protected override string Datos()
        {
            StringBuilder sb = new StringBuilder(base.Datos());
            sb.AppendLine($"Modelo: {this.Modelo}.");
            return sb.ToString();
        }

        public void Encordar()
        {
            this.EstaEncordado = true;
        }
        public void Afinar()
        {
            this.EstaAfinado = true;
        }
        #endregion

        #region Operators
        public static bool operator ==(Violin v1, Violin v2)
        {
            return (v1.ID == v2.ID);
        }
        public static bool operator !=(Violin v1, Violin v2)
        {
            return !(v1 == v2);
        }
       
        #endregion
    }
}

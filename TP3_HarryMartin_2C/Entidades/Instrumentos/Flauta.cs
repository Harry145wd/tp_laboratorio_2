using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Flauta : Instrumento, ILimpiable, IAfinable, ITerminado
    {
        #region Atributes
        private bool estaLimpio;
        private bool estaAfinado;
        #endregion

        #region Properties
        public bool EstaLimpio 
        {
            get { return this.estaLimpio; }
            set { this.estaLimpio = value; }
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
                return (EstaLimpio && EstaAfinado);
            }
        }

        #endregion

        #region Constructors
        public Flauta(string luthier, DateTime fecha) : base(luthier, fecha)
        {
            this.TipoInstrumento = eTipoInstrumento.Flauta;
        }

        #endregion

        #region Methods
        public void Limpiar()
        {
            this.EstaLimpio = true;
        }
        public void Afinar()
        {
            this.EstaAfinado=true;
        }
        public string Estado()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Esta Limpia: {Instrumento.BooleanToSiNo(this.EstaLimpio)}");
            sb.AppendLine($"Esta Afinada: {Instrumento.BooleanToSiNo(this.EstaAfinado)}");
            return sb.ToString();
        }
        protected override string Datos()
        {
            StringBuilder sb = new StringBuilder(base.Datos());
            sb.AppendLine(this.Estado());
            return sb.ToString();

        }
        #endregion

        #region Operators
        #endregion
    }
}

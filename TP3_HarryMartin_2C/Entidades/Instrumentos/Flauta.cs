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
        /// <summary>
        /// Inicializa el nombre del Luthier y la fecha de creacion del instrumento con los datos pasados por parametro
        /// </summary>
        /// <param name="luthier"></param>
        /// <param name="fecha"></param>
        public Flauta(string luthier, DateTime fecha) : base(luthier, fecha)
        {
            this.TipoInstrumento = eTipoInstrumento.Flauta;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Establece el estado EstaLimpio en true
        /// </summary>
        public void Limpiar()
        {
            this.EstaLimpio = true;
        }
        /// <summary>
        /// Establece el estado EstaAfinado en true
        /// </summary>
        public void Afinar()
        {
            this.EstaAfinado=true;
        }
        /// <summary>
        /// Muestra los estados del instrumento
        /// </summary>
        /// <returns>Stirng con los estados del instrumento con valores de Si o No</returns>
        public string Estado()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Esta Limpia: {Instrumento.BooleanToSiNo(this.EstaLimpio)}");
            sb.AppendLine($"Esta Afinada: {Instrumento.BooleanToSiNo(this.EstaAfinado)}");
            return sb.ToString();
        }
        /// <summary>
        /// Muestra los datos y estados del Instrumento
        /// </summary>
        /// <returns>string con los datos y estados</returns>
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

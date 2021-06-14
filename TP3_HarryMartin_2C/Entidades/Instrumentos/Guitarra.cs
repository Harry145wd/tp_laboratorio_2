using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Guitarra : Instrumento , IBarnizable, ICuerdas, IAfinable, ITerminado
    {
        #region Atributes
        private bool estaBarnizado;
        private bool estaEncordado;
        private bool estaAfinado;
        #endregion

        #region Properties
        public bool EstaBarnizado
        {
            get { return this.estaBarnizado; }
            set { this.estaBarnizado = value; }
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
                return (EstaEncordado && EstaAfinado && EstaBarnizado);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Inicializa el nombre del Luthier y la fecha de creacion del instrumento con los datos pasados por parametro
        /// </summary>
        /// <param name="luthier"></param>
        /// <param name="fecha"></param>
        public Guitarra(string luthier, DateTime fecha) : base(luthier, fecha)
        {
            this.TipoInstrumento = eTipoInstrumento.Guitarra;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Establece el estado EstaBarnizado en true
        /// </summary>
        public void Barnizar()
        {
            this.EstaBarnizado = true;
        }
        /// <summary>
        /// Establece el estado EstaEncordado en true
        /// </summary>
        public void Encordar()
        {
            this.EstaEncordado = true;
        }
        /// <summary>
        /// Establece el estado EstaAfinado en true
        /// </summary>
        public void Afinar()
        {
            this.EstaAfinado = true;
        }
        /// <summary>
        /// Muestra los estados del instrumento
        /// </summary>
        /// <returns>Stirng con los estados del instrumento con valores de Si o No</returns>
        public string Estado()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Esta Barnizado: {Instrumento.BooleanToSiNo(this.EstaBarnizado)}");
            sb.AppendLine($"Esta Encordado: {Instrumento.BooleanToSiNo(this.EstaEncordado)}");
            sb.AppendLine($"Esta Afinado: {Instrumento.BooleanToSiNo(this.EstaAfinado)}");
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

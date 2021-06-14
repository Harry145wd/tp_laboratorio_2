using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public abstract class Instrumento 
    {
        #region Atributes
        protected eTipoInstrumento tipoInstrumento;
        protected string luthier;
        protected DateTime fechaFabricacion;
        protected Guid id;

        #endregion

        #region Enums




        #endregion

        #region Properties

        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime FechaFabricacion
        {
            get { return fechaFabricacion; }
            set { fechaFabricacion = value; }
        }
        public string Luthier
        {
            get { return luthier; }
            set 
            { 
                if(!string.IsNullOrEmpty(value))
                {
                    luthier = value;
                }
            }
        }
        public eTipoInstrumento TipoInstrumento
        {
            get { return this.tipoInstrumento; }
            set { this.tipoInstrumento = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Inicializa la ID, fecha de creacion y nombre de luthier con valores predeterminados
        /// </summary>
        protected Instrumento()
        {
            this.ID = Guid.NewGuid();
            this.FechaFabricacion = DateTime.Now;
            this.Luthier = "Desconocido";
        }
        /// <summary>
        /// Inicializa la fecha de creacion y nombre de luthier con valores por parametro
        /// </summary>
        /// <param name="luthier"></param>
        /// <param name="fecha"></param>
        public Instrumento(string luthier, DateTime fecha) : this()
        {
            this.Luthier = luthier;
            this.FechaFabricacion = fecha;
        }
        #endregion

        #region Methods
        
        /// <summary>
        /// Muestra los datos del Instrumento
        /// </summary>
        /// <returns>string con los datos del Instrumento</returns>
        protected virtual string Datos()
        {
            StringBuilder sb = new StringBuilder($"{this.TipoInstrumento}.\n");
            sb.AppendLine($"ID: {this.ID}");
            sb.AppendLine($"Luthier: {this.Luthier}.");
            sb.AppendLine($"Fecha de Fabricacion: {this.FechaFabricacion.ToString("dd/MM/yyyy HH:mm")}");
            return sb.ToString();
        }
        /// <summary>
        /// Muestra los datos del Instrumento
        /// </summary>
        /// <returns>string con los datos del Instrumento</returns>
        public override string ToString()
        {
            return this.Datos();
        }
       
        /// <summary>
        /// Reemplaza True o False por valores Si o No
        /// </summary>
        /// <param name="state"></param>
        /// <returns>String "Si" para True y "No" para False</returns>
        public static string BooleanToSiNo(bool state)
        {
            string ret = "No";
            if(state)
            {
                ret = "Si";
            }
            return ret;
        }
        #endregion

        #region Operators
        
        #endregion
    }
}

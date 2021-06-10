using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Instrumento
    {
        #region Atributes
        protected static eTipoInstrumento tipoInstrumento;
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
            set { luthier = value; }
        }
        public static eTipoInstrumento TipoInstrumento
        {
            get { return tipoInstrumento; }
            set { tipoInstrumento = value; }
        }



        #endregion

        #region Constructors
        public Instrumento()
        {
            this.ID = Guid.NewGuid();
            this.FechaFabricacion = DateTime.Now;
            this.Luthier = "Desconocido";
        }
        public Instrumento(string luthier, DateTime fecha) : this()
        {
            this.Luthier = luthier;
            this.FechaFabricacion = fecha;
        }
        #endregion

        #region Methods
        protected virtual string Datos()
        {
            StringBuilder sb = new StringBuilder($"Instrumento: {TipoInstrumento}.\n");
            sb.AppendLine($"ID: {this.ID}");
            sb.AppendLine($"Luthier: {this.Luthier}.");
            sb.AppendLine($"Fecha de Fabricacion: {this.FechaFabricacion.ToString("dd/MM/yyyy")}");
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Datos();
        }
        public static int CompararPorNombre(Instrumento i1 , Instrumento i2)
        {
            return string.Compare(i1.GetType().Name, i2.GetType().Name);
        }
        public static void OrdenarInstrumentosPorTipo(List<Instrumento> listaInstrumentos)
        {
            listaInstrumentos.Sort(Instrumento.CompararPorNombre);
        }
        #endregion

        #region Operators

        #endregion
    }
}

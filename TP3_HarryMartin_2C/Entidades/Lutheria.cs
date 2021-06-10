using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lutheria
    {
        #region Atributes
        protected Almacen almacen;
        protected List<Instrumento> instrumentosEnProceso;


        #endregion

        #region Properties
        public Almacen Almacen
        {
            get { return almacen; }
            set { almacen = value; }
        }
        public List<Instrumento> InstrumentosEnProceso
        {
            get
            {
                return this.instrumentosEnProceso;
            }
            set
            {
                this.instrumentosEnProceso = value;
            }
        }
        #endregion

        #region Constructors

        public Lutheria()
        {
            this.Almacen = new Almacen();
            this.InstrumentosEnProceso = new List<Instrumento>();
        }
        #endregion

        #region Methods
        //PREGUNTAR A LAUTI
        public Instrumento CrearInstrumento(eTipoInstrumento tipoInstrumento)
        {
            Instrumento nuevoInstrumento = null;
            if (this.almacen.HaySuficientesMateriales(tipoInstrumento))
            {
                switch(tipoInstrumento)
                {
                    case eTipoInstrumento.Violin:
                    {
                        nuevoInstrumento = new Violin();
                        break;
                    }
                    case eTipoInstrumento.Guitarra:
                    {
                        nuevoInstrumento = new Guitarra();
                        break;
                    }
                    case eTipoInstrumento.Flauta:
                    {
                        nuevoInstrumento = new Flauta();
                        break;
                    }
                }
            }
            else 
            {
                throw new Exception("No hay suficientes Materiales");
            }
            return nuevoInstrumento;
        }

        public string MostrarInstrumentosEnProceso()
        {
            StringBuilder sb = new StringBuilder();
            Instrumento.OrdenarInstrumentosPorTipo(this.InstrumentosEnProceso);
            foreach (Instrumento instrumento in this.InstrumentosEnProceso)
            {
                sb.AppendLine(instrumento.ToString());
                sb.AppendLine("-----------------------------------------");
            }
            return sb.ToString();
        }
        #endregion

        #region Operators
        #endregion

    } 
}

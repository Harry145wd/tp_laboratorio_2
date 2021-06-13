using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Lutheria : IListaDeInstrumentos, IProceso<Instrumento>
    {
        #region Atributes
        private Almacen almacen;
        private Barnizadora barnizadora;
        private Encordadora encordadora;
        private Afinadora afinadora;
        private Limpiadora limpiadora;
        private List<Instrumento> instrumentosEnProceso;

        #endregion

        #region Properties
        public Almacen Almacen
        {
            get { return almacen; }
            set { almacen = value; }
        }
        public Barnizadora Barnizadora
        {
            get { return barnizadora; }
            set { barnizadora = value; }
        }
        public Limpiadora Limpiadora
        {
            get { return limpiadora; }
            set { limpiadora = value; }
        }
        public Afinadora Afinadora
        {
            get { return afinadora; }
            set { afinadora = value; }
        }
        public Encordadora Encordadora
        {
            get { return encordadora; }
            set { encordadora = value; }
        }
        public List<Instrumento> ListaDeInstrumentos
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
            this.Barnizadora = new Barnizadora();
            this.Encordadora = new Encordadora();
            this.Afinadora = new Afinadora();
            this.Limpiadora = new Limpiadora();
            this.ListaDeInstrumentos = new List<Instrumento>();
            this.Almacen[eMaterial.Madera].ReStock(30);
            this.Almacen[eMaterial.Metal].ReStock(30);
            this.Almacen[eMaterial.Plastico].ReStock(30);
        }
        #endregion

        #region Methods
        public Instrumento CrearInstrumento(eTipoInstrumento tipoInstrumento, string luthier, DateTime dateTime)
        {
            Instrumento nuevoInstrumento = null;
            try
            {
                if (this.almacen.HaySuficientesMateriales(tipoInstrumento))
                {
                    switch (tipoInstrumento)
                    {
                        case eTipoInstrumento.Violin:
                            {
                                nuevoInstrumento = new Violin(luthier, dateTime);
                                this.GastarMaterialesViolin();
                                break;
                            }
                        case eTipoInstrumento.Guitarra:
                            {
                                nuevoInstrumento = new Guitarra(luthier, dateTime);
                                this.GastarMaterialesGuitarra();
                                break;
                            }
                        case eTipoInstrumento.Flauta:
                            {
                                nuevoInstrumento = new Flauta(luthier, dateTime);
                                this.GastarMaterialesFlauta();
                                break;
                            }
                    }
                }
            }
            catch(NotEnoughMaterialsException exc)
            {
                throw exc;
            }
            return nuevoInstrumento;
        }

        public void GastarMaterialesViolin()
        {
            this.Almacen[eMaterial.Madera].DeStock(Almacen[eTipoInstrumento.Violin, eMaterial.Madera].CostoDeMaterial);
            this.Almacen[eMaterial.Metal].DeStock(Almacen[eTipoInstrumento.Violin, eMaterial.Metal].CostoDeMaterial);
            this.Almacen[eMaterial.Plastico].DeStock(Almacen[eTipoInstrumento.Violin, eMaterial.Plastico].CostoDeMaterial);
        }
        public void GastarMaterialesGuitarra()
        {
            this.Almacen[eMaterial.Madera].DeStock(Almacen[eTipoInstrumento.Guitarra, eMaterial.Madera].CostoDeMaterial);
            this.Almacen[eMaterial.Metal].DeStock(Almacen[eTipoInstrumento.Guitarra, eMaterial.Metal].CostoDeMaterial);
            this.Almacen[eMaterial.Plastico].DeStock(Almacen[eTipoInstrumento.Guitarra, eMaterial.Plastico].CostoDeMaterial);
        }
        public void GastarMaterialesFlauta()
        {
            this.Almacen[eMaterial.Madera].DeStock(Almacen[eTipoInstrumento.Flauta, eMaterial.Madera].CostoDeMaterial);
            this.Almacen[eMaterial.Metal].DeStock(Almacen[eTipoInstrumento.Flauta, eMaterial.Metal].CostoDeMaterial);
            this.Almacen[eMaterial.Plastico].DeStock(Almacen[eTipoInstrumento.Flauta, eMaterial.Plastico].CostoDeMaterial);
        }
        public string MostrarInstrumentosEnProceso()
        {
            StringBuilder sb = new StringBuilder();
            Instrumento.OrdenarInstrumentosPorTipo(this.ListaDeInstrumentos);
            foreach (Instrumento instrumento in this.ListaDeInstrumentos)
            {
                sb.AppendLine(instrumento.ToString());
                sb.AppendLine("-----------------------------------------");
            }
            return sb.ToString();
        }

        public bool ValidarPasaje(Instrumento instrumento)
        {
            return true;
        }
        public void PasarA<T>(T receptora, Instrumento instrumento) where T : IListaDeInstrumentos,IProceso<Instrumento>
        {
            if (receptora.ValidarPasaje(instrumento))
            {
                receptora.Procesar(instrumento);
                receptora.ListaDeInstrumentos.Add(instrumento);
                this.ListaDeInstrumentos.Remove(instrumento);
            }
        }

        public void Procesar(Instrumento item)
        {
            
        }
        #endregion

        #region Operators
        #endregion

    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Almacen
    {
        #region Atributes
        private List<Stock> stocksMateriasPrimas;
        private List<Instrumento> stockInstrumentos;
        private List<Costo> costoInstrumentos;

        #endregion

        #region Properties
        //utilizo indexadores para obtener un stock segun el material
        public Stock this[eMaterial material]
        {
            get 
            {
                Stock ret = null;
                foreach(Stock aux in this.StocksMateriasPrimas)
                {
                    if(aux == material)
                    {
                        ret = aux;
                        break;
                    }
                }
                return ret;
            }
        }
        //utilizo indexadores para obtener un costo segun el instrumento y el material
        public Costo this[eTipoInstrumento tipo,eMaterial material]
        {
            get
            {
                Costo ret = null;
                foreach (Costo costo in this.Costos)
                {
                    if(costo.TipoInstrumento == tipo && costo.Material == material)
                    {
                        ret = costo;
                        break;
                    }
                }
                return ret;
            }
        }
        public List<Instrumento> StockInstrumentos
        {
            get { return stockInstrumentos; }
            set { stockInstrumentos = value; }
        }
        public List<Stock> StocksMateriasPrimas
        {
            get { return stocksMateriasPrimas; }
            set { stocksMateriasPrimas = value; }
        }
        public List<Costo> Costos
        {
            get { return this.costoInstrumentos; }
            set { this.costoInstrumentos = value; }
        }
        #endregion

        #region Constructors
        public Almacen()
        {
            this.StockInstrumentos = new List<Instrumento>();
            this.StocksMateriasPrimas = new List<Stock>();
            this.Costos = new List<Costo>();
            this.StocksMateriasPrimas.Add(new Stock(eMaterial.Madera));
            this.StocksMateriasPrimas.Add(new Stock(eMaterial.Metal));
            this.StocksMateriasPrimas.Add(new Stock(eMaterial.Plastico));
            this.Costos.Add(new Costo(eTipoInstrumento.Violin, eMaterial.Madera, 5));
            this.Costos.Add(new Costo(eTipoInstrumento.Violin, eMaterial.Metal, 3));
            this.Costos.Add(new Costo(eTipoInstrumento.Violin, eMaterial.Plastico, 2));
            this.Costos.Add(new Costo(eTipoInstrumento.Guitarra, eMaterial.Madera, 7));
            this.Costos.Add(new Costo(eTipoInstrumento.Guitarra, eMaterial.Metal, 4));
            this.Costos.Add(new Costo(eTipoInstrumento.Guitarra, eMaterial.Plastico, 3));
            this.Costos.Add(new Costo(eTipoInstrumento.Flauta, eMaterial.Madera, 1));
            this.Costos.Add(new Costo(eTipoInstrumento.Flauta, eMaterial.Metal, 5));
            this.Costos.Add(new Costo(eTipoInstrumento.Flauta, eMaterial.Plastico, 2));
        }
        public Almacen(int madera, int plastico, int metal): this()
        {
            try
            {
                this[eMaterial.Madera].ReStock(madera);
                this[eMaterial.Metal].ReStock(metal);
                this[eMaterial.Plastico].ReStock(plastico);
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException("No se pudo stockear correctamente", e);
            }
        }
        public Almacen(int madera, int plastico, int metal, List<Instrumento> instrumentos) : this(madera, plastico, metal)
        {
            this.ReStock(instrumentos);
        }

        #endregion

        #region Methods
        public void ReStock<T>(T instrumento) where T : Instrumento
        {
            this.StockInstrumentos.Add(instrumento);
        }
        public void ReStock<T>(List<T> listaInstrumentos) where T : Instrumento
        {
            this.StockInstrumentos = this.StockInstrumentos.Union(listaInstrumentos).ToList();
        }
        public string MostrarMateriasPrimas()
        {
            StringBuilder sb = new StringBuilder("Lista de materia prima:\n");
            foreach (Stock stock in this.StocksMateriasPrimas)
            {
                sb.AppendLine(stock.ToString());
            }
            sb.AppendLine("-----------------------------------------");
            return sb.ToString();
        }
        public string MostrarInstrumentosEnStock()
        {
            StringBuilder sb = new StringBuilder("Lista de Instrumentos en stock:\n");
            sb.AppendLine("-----------------------------------------");
            if(this.StockInstrumentos.Count != 0)
            {
                Instrumento.OrdenarInstrumentosPorTipo(this.stockInstrumentos);
                foreach (Instrumento instrumento in this.StockInstrumentos)
                {
                    sb.AppendLine(instrumento.ToString());
                    sb.AppendLine("-----------------------------------------");
                }
            }
            else
            {
                sb.AppendLine("No hay instrumentos en Stock");
            }
            
            
            return sb.ToString();
        }
        public string HacerInventario()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.MostrarMateriasPrimas());
            sb.AppendLine(this.MostrarInstrumentosEnStock());
            return sb.ToString();
        }

        //revisar
        public bool HaySuficienteMaterial(eTipoInstrumento tipo, eMaterial material)
        {
            bool ret = false;
            //DEBERIA USAR UN CONTAINS?
            foreach(Costo costo in this.Costos)
            {
                if(costo.TipoInstrumento == tipo && costo.Material == material)
                {
                    if (this[material].Cantidad >= costo.CostoDeMaterial)
                    {
                        ret = true;
                    }
                    else
                    {
                        throw new NotEnoughMaterialsException($"No hay suficiente {material.ToString()} en stock para crear un {tipo.ToString()}");
                    }
                    break;
                }
            }
            return ret;  
        }
        public bool HaySuficientesMateriales(eTipoInstrumento tipo)
        {
            bool ret = true;
            Array arrayMateriales = Enum.GetValues(typeof(eMaterial));
            foreach(eMaterial material in arrayMateriales)
            {
                if(!this.HaySuficienteMaterial(tipo, material))
                {
                    ret = false;
                }

            }
            return ret;
        }
        //
        
        public override string ToString()
        {
            return this.HacerInventario();
        }
        #endregion

        #region Operators
        #endregion

    }
}

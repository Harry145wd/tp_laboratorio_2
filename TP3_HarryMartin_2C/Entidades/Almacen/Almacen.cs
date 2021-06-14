using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Almacen : IListaDeInstrumentos, IProceso<Instrumento>
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
        public List<Instrumento> ListaDeInstrumentos
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
        /// <summary>
        /// Constructor sin parametros, Inicializa Listas de Costos y Materiales en Stock con valores Standart
        /// </summary>
        public Almacen()
        {
            this.ListaDeInstrumentos = new List<Instrumento>();
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
        /// <summary>
        /// Constructor sin parametros, Inicializa Listas de Costos y Materiales en Stock con valores por parametro
        /// </summary>
        /// <param name="madera"></param>
        /// <param name="plastico"></param>
        /// <param name="metal"></param>
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

        #endregion

        #region Methods
        /// <summary>
        /// Añade un elemento de clase Instrumento o derivadas a la lista de instrumentos en el Almacen
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instrumento"></param>
        public void ReStock<T>(T instrumento) where T : Instrumento
        {
            this.ListaDeInstrumentos.Add(instrumento);
        }
        /// <summary>
        /// Añade una lista de Instrumentos o clases derivadas a la lista de instrumentos en el Almacen
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listaInstrumentos"></param>
        public void ReStock<T>(List<T> listaInstrumentos) where T : Instrumento
        {
            this.ListaDeInstrumentos = this.ListaDeInstrumentos.Union(listaInstrumentos).ToList();
        }
        
        /// <summary>
        /// devuelve un string con la lista de valores de materias primas en stock
        /// </summary>
        /// <returns>string con materias primas y sus valores actuales</returns>
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
        /// <summary>
        /// devuelve un string con la lista de los Instrumentos en stock
        /// </summary>
        /// <returns>string con Instrumentos en stock</returns>
        public string MostrarInstrumentosEnStock()
        {
            StringBuilder sb = new StringBuilder("Lista de Instrumentos en stock:\n");
            sb.AppendLine("-----------------------------------------");
            if(this.ListaDeInstrumentos.Count != 0)
            {
                foreach (Instrumento instrumento in this.ListaDeInstrumentos)
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
        /// <summary>
        ///  devuelve un string con la lista de valores de materias primas y la lista de Instrumentos en stock
        /// </summary>
        /// <returns>string con materias primas y Instrumentos en stock</returns>
        public string HacerInventario()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.MostrarMateriasPrimas());
            sb.AppendLine(this.MostrarInstrumentosEnStock());
            return sb.ToString();
        }
        /// <summary>
        /// Verifica si hay cierta cantidad de un material necesario para construir un instrumento 
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="material"></param>
        /// <returns>True si hay suficiente del material especificado para construir el instrumento especificado</returns>
        public bool HaySuficienteMaterial(eTipoInstrumento tipo, eMaterial material)
        {
            bool ret = false;
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
        /// <summary>
        /// Verifica si hay suficiente de todos los materiales necesarios para construir un Instrumento 
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>True si hay suficientes materiales para construir el instrumento especificado</returns>
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
        /// <summary>
        /// Muestra todo lo contenido en el Almacen (materias primas e Instrumentos)
        /// </summary>
        /// <returns>string con todos los contenidos del Almacen</returns>
        public override string ToString()
        {
            return this.HacerInventario();
        }
        /// <summary>
        /// Valida que el instrumento por parametro pueda agregarse a la lista del almacen
        /// </summary>
        /// <param name="instrumento"></param>
        /// <returns>True si el instrumento especificado esta terminado</returns>
        public bool ValidarPasaje(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is ITerminado)
            {
                ITerminado iterminado = (ITerminado)instrumento;
                if (iterminado.Terminado)
                {
                    ret = true;
                }
                else
                {
                    throw new Exception("Este instrumento no puede pasarse al Almacen ya que no esta terminado");
                }
            }
            return ret;
        }
        /// <summary>
        /// Pasa el Instrumento especificado de la lista del almacen a la lista especificada por parametro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="receptora"></param>
        /// <param name="instrumento"></param>
        public void PasarA<T>(T receptora, Instrumento instrumento) where T : IListaDeInstrumentos, IProceso<Instrumento>
        {
            if (receptora.ValidarPasaje(instrumento))
            {
                receptora.Procesar(instrumento);
                receptora.ListaDeInstrumentos.Add(instrumento);
                this.ListaDeInstrumentos.Remove(instrumento);
            }
        }
        /// <summary>
        /// Funcion no implementada(No se puede usar excepcion ya que simplemnete debe no hacer nada)
        /// </summary>
        /// <param name="item"></param>
        public void Procesar(Instrumento item)
        {
             
        }
        #endregion

        #region Operators
        #endregion

    }
}
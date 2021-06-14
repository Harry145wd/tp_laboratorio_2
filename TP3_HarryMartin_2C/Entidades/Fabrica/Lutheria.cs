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
        /// <summary>
        /// Inicializa una lista de Instrumentos vacia, Instancia los objetos: Almacen(Con valores por defecto), Barnizadora, Encordadora, Afinadora,Limpiadora
        /// </summary>
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
        /// <summary>
        /// Crea y devuelve un Instrumento en base a los valores por parametro, Solamente si tiene los materiales necesarios en Stock
        /// </summary>
        /// <param name="tipoInstrumento"></param>
        /// <param name="luthier"></param>
        /// <param name="dateTime"></param>
        /// <returns>Instrumento si se pudo crear el instrumento o Null</returns>
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
        /// <summary>
        /// Gasta los materiales requeridos para crear un Violin
        /// </summary>
        public void GastarMaterialesViolin()
        {
            this.Almacen[eMaterial.Madera].DeStock(Almacen[eTipoInstrumento.Violin, eMaterial.Madera].CostoDeMaterial);
            this.Almacen[eMaterial.Metal].DeStock(Almacen[eTipoInstrumento.Violin, eMaterial.Metal].CostoDeMaterial);
            this.Almacen[eMaterial.Plastico].DeStock(Almacen[eTipoInstrumento.Violin, eMaterial.Plastico].CostoDeMaterial);
        }
        /// <summary>
        /// Gasta los materiales requeridos para crear un Guitarra
        /// </summary>
        public void GastarMaterialesGuitarra()
        {
            this.Almacen[eMaterial.Madera].DeStock(Almacen[eTipoInstrumento.Guitarra, eMaterial.Madera].CostoDeMaterial);
            this.Almacen[eMaterial.Metal].DeStock(Almacen[eTipoInstrumento.Guitarra, eMaterial.Metal].CostoDeMaterial);
            this.Almacen[eMaterial.Plastico].DeStock(Almacen[eTipoInstrumento.Guitarra, eMaterial.Plastico].CostoDeMaterial);
        }
        /// <summary>
        /// Gasta los materiales requeridos para crear una Flauta
        /// </summary>
        public void GastarMaterialesFlauta()
        {
            this.Almacen[eMaterial.Madera].DeStock(Almacen[eTipoInstrumento.Flauta, eMaterial.Madera].CostoDeMaterial);
            this.Almacen[eMaterial.Metal].DeStock(Almacen[eTipoInstrumento.Flauta, eMaterial.Metal].CostoDeMaterial);
            this.Almacen[eMaterial.Plastico].DeStock(Almacen[eTipoInstrumento.Flauta, eMaterial.Plastico].CostoDeMaterial);
        }
        /// <summary>
        /// Muestra los Instrumentos en la lista de Recien Creados
        /// </summary>
        /// <returns>String con la lista de instrumentos Recien Creados</returns>
        public string MostrarInstrumentosEnProceso()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lista de instrumentos recien creados:");
            sb.AppendLine("-----------------------------------------");
            if (this.ListaDeInstrumentos.Count == 0)
            {
                sb.AppendLine("No hay instrumentos recien creados");
            }
            else
            {
                foreach (Instrumento instrumento in this.ListaDeInstrumentos)
                {
                    sb.AppendLine(instrumento.ToString());
                    sb.AppendLine("-----------------------------------------");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Valida que el instrumento por parametro pueda agregarse a la lista de Recien Creados 
        /// </summary>
        /// <param name="instrumento"></param>
        /// <returns></returns>
        public bool ValidarPasaje(Instrumento instrumento)
        {
            return true;
        }
        /// <summary>
        /// Pasa el Instrumento especificado de la lista de la Lista de Recien Creados a la lista especificada por parametro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="receptora"></param>
        /// <param name="instrumento"></param>
        public void PasarA<T>(T receptora, Instrumento instrumento) where T : IListaDeInstrumentos,IProceso<Instrumento>
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

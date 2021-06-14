using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Lutheria lutheria = new Lutheria();
            Instrumento nuevoInstrumento = lutheria.CrearInstrumento(eTipoInstrumento.Violin, "Pepe", DateTime.Now);
            Instrumento nuevoInstrumento1 = lutheria.CrearInstrumento(eTipoInstrumento.Flauta, "Pepe1", DateTime.Now);
            Instrumento nuevoInstrumento2 = lutheria.CrearInstrumento(eTipoInstrumento.Guitarra, "Pepe2", DateTime.Now);
            lutheria.ListaDeInstrumentos.Add(nuevoInstrumento);
            lutheria.ListaDeInstrumentos.Add(nuevoInstrumento1);
            lutheria.ListaDeInstrumentos.Add(nuevoInstrumento2);
            #region Proceso del violin
            lutheria.PasarA(lutheria.Barnizadora, lutheria.ListaDeInstrumentos[0]);
            lutheria.Barnizadora.PasarA(lutheria.Encordadora, lutheria.Barnizadora.ListaDeInstrumentos[0]);
            lutheria.Encordadora.PasarA(lutheria.Afinadora, lutheria.Encordadora.ListaDeInstrumentos[0]);
            lutheria.Afinadora.PasarA(lutheria.Almacen, lutheria.Afinadora.ListaDeInstrumentos[0]);
            #endregion
            #region Proceso de la Flauta
            lutheria.PasarA(lutheria.Limpiadora, lutheria.ListaDeInstrumentos[0]);
            lutheria.Limpiadora.PasarA(lutheria.Afinadora, lutheria.Limpiadora.ListaDeInstrumentos[0]);
            lutheria.Afinadora.PasarA(lutheria.Almacen, lutheria.Afinadora.ListaDeInstrumentos[0]);
            #endregion
            Console.WriteLine(lutheria.Almacen.ToString());
            Console.WriteLine(lutheria.MostrarInstrumentosEnProceso());
            Console.ReadKey();
        }
    }
}

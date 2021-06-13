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
            Instrumento nuevoInstrumento1 = lutheria.CrearInstrumento(eTipoInstrumento.Guitarra, "Pepe1", DateTime.Now);
            Instrumento nuevoInstrumento2 = lutheria.CrearInstrumento(eTipoInstrumento.Flauta, "Pepe2", DateTime.Now);
            lutheria.InstrumentosEnProceso.Add(nuevoInstrumento);
            lutheria.InstrumentosEnProceso.Add(nuevoInstrumento1);
            lutheria.InstrumentosEnProceso.Add(nuevoInstrumento2);
            Console.WriteLine(lutheria.Almacen.ToString());
            Console.WriteLine(lutheria.MostrarInstrumentosEnProceso());
            Console.ReadKey();
        }
    }
}

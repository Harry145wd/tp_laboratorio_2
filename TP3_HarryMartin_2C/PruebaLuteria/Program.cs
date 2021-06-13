using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace PruebaLuteria
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Instrumento> instrumentos = new List<Instrumento>();
            List<Instrumento> instrumentos1 = new List<Instrumento>();
            instrumentos.Add(new Violin("Cucho",DateTime.Now));
            instrumentos.Add(new Violin("Stradella", DateTime.Now));
            instrumentos1.Add(new Violin("Stradivarius", new DateTime(1899,03,14)));
            instrumentos = instrumentos.Union(instrumentos1).ToList();
            Almacen almacen = new Almacen(15, 10, 14, instrumentos);
            Console.WriteLine(almacen.ToString());
            Console.ReadKey();
        }
    }
}

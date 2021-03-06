using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo 
        { CuatroPuertas, 
            CincoPuertas 
        }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// 
        public Sedan(string chasis, EMarca marca, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        public Sedan(string chasis, EMarca marca, ConsoleColor color) : this(chasis,marca,color,ETipo.CuatroPuertas)
        {
        }
        

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}\n", this.Tamanio);
            sb.AppendFormat("TIPO : {0}\n", this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

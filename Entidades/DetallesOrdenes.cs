using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipoParcial.Entidades
{
    public class DetallesOrdenes
    {
        public Materiales Material { get; set; }
        public int Cantidad { get; set; }
        public DetallesOrdenes()
        {
            Material = new Materiales();
            Cantidad = 0;
        }
        public DetallesOrdenes(Materiales material, int catidad)
        {
            this.Material = material;
            this.Cantidad = catidad;
        }
    }
}

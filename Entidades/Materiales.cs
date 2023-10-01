using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipoParcial.Entidades
{
    public class Materiales
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Stock { get; set; }

        public Materiales()
        {
                Codigo = 0;
            Stock = 0;
            Nombre = string.Empty;
        }
        public Materiales(int codigo, double stock, string nombre)
        {
            this.Codigo = codigo;
            this.Stock = stock;
            this.Nombre = nombre;
        }

        public string MostrarMaterial()
        {
            return Nombre;
        }
    }
}

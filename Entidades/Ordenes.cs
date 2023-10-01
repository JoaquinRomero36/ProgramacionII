using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipoParcial.Entidades
{
    public class Ordenes
    {
      public int NroOrden { get; set; }
        public List<DetallesOrdenes> lDetlles { get; set; }
        public DateTime Fecha { get; set; }
        public string Responsable { get; set; }
        public Ordenes(int nroOrden, DateTime fecha, string responsable)
        {
            NroOrden= nroOrden;
            Fecha = fecha;
            Responsable = responsable;
        }
        public Ordenes()
        {
            lDetlles = new List<DetallesOrdenes>();
        }
        public void QgregarDetalle(DetallesOrdenes detalle)
        {
            lDetlles.Add(detalle);
        }
        public void QuitarDEtalle(int posicion)
        {
            lDetlles.RemoveAt(posicion);
        }
    }
}

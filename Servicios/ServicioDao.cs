using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipoParcial.Datos.implementacion;
using TipoParcial.Datos.interfaz;
using TipoParcial.Entidades;

namespace TipoParcial.Servicios
{
    //Joaquin romero Beskow 1w1 405632
    internal class ServicioDao : IServicio
    {
        private IOrdenes dao;
        public ServicioDao()
        {
            dao = new OrdenesDao();
        }
        public bool CrearOrden(Ordenes ordenes)
        {
            return dao.CrearOrden(ordenes);
        }

        public List<Materiales> TraerMateriales()
        {
            return  dao.ObtenerMateriales();
        }
    }
}

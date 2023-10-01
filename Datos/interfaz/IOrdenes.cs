using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipoParcial.Entidades;

namespace TipoParcial.Datos.interfaz
{
    public interface IOrdenes
    {
       List<Materiales> ObtenerMateriales();
        bool CrearOrden(Ordenes ordenes);
    }
}

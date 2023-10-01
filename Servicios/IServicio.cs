using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipoParcial.Entidades;

namespace TipoParcial.Servicios
{
    internal interface IServicio
    {
   
        
        List<Materiales> TraerMateriales();

        bool CrearOrden(Ordenes ordenes);
    }
}

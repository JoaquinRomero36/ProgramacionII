using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipoParcial.Datos.interfaz;
using TipoParcial.Entidades;

namespace TipoParcial.Datos.implementacion
{
    //Joaquin romero Beskow 1w1 405632
    internal class OrdenesDao : IOrdenes
    {
        public bool CrearOrden(Ordenes ordenes)
        {
           bool x = true;
           SqlConnection conexion = HelperDao.OBtenerInstancia().Obtenerconexion();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = conexion.CreateCommand();
                cmd.Connection = conexion;
                cmd.Transaction = t;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERTAR_ORDEN";
                cmd.Parameters.AddWithValue("@responsable", ordenes.Responsable);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@nro";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int nroOrden = (int)param.Value;
                int nroDetalle = 1;

                SqlCommand comando;
                foreach(DetallesOrdenes d in ordenes.lDetlles)
                {
                    comando = new SqlCommand("SP_INSERTAR_DETALLES", conexion, t);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@nro_orden", nroOrden);
                    comando.Parameters.Add("@detalle", nroDetalle);
                    comando.Parameters.Add("@codigo", d.Material.Codigo);
                    comando.Parameters.Add("@cantidad", d.Cantidad);
                    comando.ExecuteNonQuery();
                    nroDetalle++;
                }
                t.Commit();
            }
            catch
            {
                if(t.Connection == null)
                {
                    t.Rollback();
                    x = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return x;
        }

        public List<Materiales> ObtenerMateriales()
        {
            List<Materiales> lMateriales = new List<Materiales>();
            DataTable dt = HelperDao.OBtenerInstancia().Consultar("SP_CONSULTAR_MATERIALES");
            //MAPEO DE LA TABLA
            foreach(DataRow Rows in dt.Rows)
            {
                int codigo = int.Parse(Rows["codigo"].ToString());
                string nombre = Rows["nombre"].ToString();
                double stock = double.Parse(Rows["Stock"].ToString());

                Materiales m = new Materiales(codigo, stock,nombre);
                lMateriales.Add(m);
            }
            return lMateriales;
        }
    }
}

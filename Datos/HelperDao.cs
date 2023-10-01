using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TipoParcial
{
    //Joaquin romero Beskow 1w1 405632
    internal class HelperDao
    {
        private static HelperDao instance;
        private SqlConnection conexion;
        public HelperDao()
        {
            conexion = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=db_ordenes;Integrated Security=True");
        }
        public static HelperDao OBtenerInstancia()
        {
            if(instance == null)
            {
                instance = new HelperDao();
            }
            return instance;
        }
        public SqlConnection Obtenerconexion()
        {
            return this.conexion;
        }
        public int ConsultarEscalar(string nombreSP, string nombreParamOut)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombreParamOut;
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;

            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery();

            conexion.Close();

            return (int)parametro.Value;
        }
        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
    }
}

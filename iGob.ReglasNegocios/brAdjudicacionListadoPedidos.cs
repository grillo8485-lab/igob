using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iGob.Entidades;
using iGob.AccesoDatos;
using System.Data.SqlClient;

namespace iGob.ReglasNegocios
{
    public class brAdjudicacionListadoPedidos : brConexion
    {
        public List<beAdjudicacionListadoPedidos> ListadoAdjudicacionesLotesPedidos(int IdDependencia)//int IdAdjudicacion, 
        {
            List<beAdjudicacionListadoPedidos> OListadoAdjudicacionesLotesPedidos = new List<beAdjudicacionListadoPedidos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionListadoPedidos a = new daAdjudicacionListadoPedidos();
                    OListadoAdjudicacionesLotesPedidos = a.ListadoAdjudicacionesLotesPedidos(con,IdDependencia);// IdAdjudicacion, 
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return OListadoAdjudicacionesLotesPedidos;
            }
        }

    }
}

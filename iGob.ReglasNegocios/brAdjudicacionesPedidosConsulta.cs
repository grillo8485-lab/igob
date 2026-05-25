using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brAdjudicacionesPedidosConsulta:brConexion
    {
        public List<beAdjudicacionesPedidosConsulta> listarAdjudicacionesPedidosConsulta(beGenerica oGenerico)
        {
            List<beAdjudicacionesPedidosConsulta> listaAdjudicacionesPedidosConsulta = new List<beAdjudicacionesPedidosConsulta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daAdjudicacionesPedidosConsulta a = new daAdjudicacionesPedidosConsulta();
                    listaAdjudicacionesPedidosConsulta = a.listarAdjudicacionesPedidosConsulta(con, oGenerico);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listaAdjudicacionesPedidosConsulta;
            }
        }
    }
}

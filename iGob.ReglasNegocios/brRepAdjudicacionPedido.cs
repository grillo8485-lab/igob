using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brRepAdjudicacionPedido:brConexion
    {
        public beRepAdjudicacionPedido traerRep_AdjudicacionPedido_x_IdAdjudicacionPedido(int IdAdjudicacionPedido)
        {
            beRepAdjudicacionPedido obeLicitaciones = new beRepAdjudicacionPedido();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRepAdjudicacionPedido odaLicitaciones = new daRepAdjudicacionPedido();
                    obeLicitaciones = odaLicitaciones.traerRep_AdjudicacionPedido_x_IdAdjudicacionPedido(con, IdAdjudicacionPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beRepAdjudicacionPedido> traerRep_AdjudicacionPedidoDetalles_x_IdAdjudicacionPedido(int IdAdjudicacionPedido)
        {
            List<beRepAdjudicacionPedido> lbeReq = new List<beRepAdjudicacionPedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRepAdjudicacionPedido odaLicitaciones = new daRepAdjudicacionPedido();
                    lbeReq = odaLicitaciones.traerRep_AdjudicacionPedidoDetalles_x_IdAdjudicacionPedido(con, IdAdjudicacionPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeReq;
            }
        }
    }
}

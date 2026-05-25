using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brRepRecepcionPedidos:brConexion
    {
        public beRepRecepcionPedidos traerRep_RecepcionPedidos_x_IdPedido(int IdPedido)
        {
            beRepRecepcionPedidos obeRep = new beRepRecepcionPedidos();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRepRecepcionPedidos odaRep = new daRepRecepcionPedidos();
                    obeRep = odaRep.traerRep_RecepcionPedidos_x_IdPedido(con, IdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRep;
            }
        }

        public List<beRepRecepcionPedidos> traerRep_RecepcionPedidosDetalles_x_IdPedido(int IdPedido)
        {
            List<beRepRecepcionPedidos> lbeRep = new List<beRepRecepcionPedidos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRepRecepcionPedidos odaRep = new daRepRecepcionPedidos();
                    lbeRep = odaRep.traerRep_RecepcionPedidosDetalles_x_IdPedido(con, IdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRep;
            }
        }
    }
}

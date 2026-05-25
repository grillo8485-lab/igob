using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitacionesRecepcionPedido:brConexion
    {
        public beLicitacionesRecepcionPedido traerRecepcionPedido_x_IdRecepcion(int IdRecepcion)
        {
            beLicitacionesRecepcionPedido obeLicitaciones = new beLicitacionesRecepcionPedido();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesRecepcionPedido odaLicitaciones = new daLicitacionesRecepcionPedido();
                    obeLicitaciones = odaLicitaciones.traerRecepcionPedido_x_IdRecepcion(con, IdRecepcion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesRecepcionPedido> traerRecepcionesPedidosDetalles_x_IdRecepcion(int IdRecepcion)
        {
            List<beLicitacionesRecepcionPedido> lbeLicitacionesActaFallo = new List<beLicitacionesRecepcionPedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesRecepcionPedido odaLicitaciones = new daLicitacionesRecepcionPedido();
                    lbeLicitacionesActaFallo = odaLicitaciones.traerRecepcionesPedidosDetalles_x_IdRecepcion(con, IdRecepcion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesActaFallo;
            }
        }
    }
}

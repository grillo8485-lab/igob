using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitacionesPedido:brConexion
    {
        public beLicitacionesPedido traerPedido_x_IdPedido(int IdPedido)
        {
            beLicitacionesPedido obeLicitaciones = new beLicitacionesPedido();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesPedido odaLicitaciones = new daLicitacionesPedido();
                    obeLicitaciones = odaLicitaciones.traerPedido_x_IdPedido(con, IdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesPedido> traerPedidoDetalles_x_IdPedido(int IdPedido)
        {
            List<beLicitacionesPedido> lbeLicitacionesActaFallo = new List<beLicitacionesPedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesPedido odaLicitaciones = new daLicitacionesPedido();
                    lbeLicitacionesActaFallo = odaLicitaciones.traerPedidoDetalles_x_IdPedido(con, IdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesActaFallo;
            }
        }

        public List<beLicitacionesPedido> traerPedido_Manifiestos_x_IdPedido(int IdPedido)
        {
            List<beLicitacionesPedido> lbeLicitacionesActaFallo = new List<beLicitacionesPedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesPedido odaLicitaciones = new daLicitacionesPedido();
                    lbeLicitacionesActaFallo = odaLicitaciones.traerPedido_Manifiestos_x_IdPedido(con, IdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesActaFallo;
            }
        }

        public List<beLicitacionesPedido> traerPedido_Firmantes_x_IdPedido(int IdPedido)
        {
            List<beLicitacionesPedido> lbeLicitacionesActaFallo = new List<beLicitacionesPedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitacionesPedido odaLicitaciones = new daLicitacionesPedido();
                    lbeLicitacionesActaFallo = odaLicitaciones.traerPedido_Firmantes_x_IdPedido(con, IdPedido);
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

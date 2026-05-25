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
    public class brAdjudicacionLiberarPedido : brConexion
    {
        public List<beAdjudicacionLiberarPedido> ListadoLotesAdjudicacionesLiberarPedido(int IdAdjudicacionPedido)
        {
            List<beAdjudicacionLiberarPedido> OListadoLotesAdjudicacionesLiberarPedido = new List<beAdjudicacionLiberarPedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daAdjudicacionLiberarPedido a = new daAdjudicacionLiberarPedido();
                    OListadoLotesAdjudicacionesLiberarPedido = a.ListadoLotesAdjudicacionesLiberarPedido(con, IdAdjudicacionPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return OListadoLotesAdjudicacionesLiberarPedido;
            }
        }

        public List<beAdjudicacionLiberarPedido> ListadoAdjudicacionPedidoEntrega(int IdPedido)
        {
            List<beAdjudicacionLiberarPedido> OListadoLotesAdjudicacionesLiberarPedido = new List<beAdjudicacionLiberarPedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daAdjudicacionLiberarPedido a = new daAdjudicacionLiberarPedido();
                    OListadoLotesAdjudicacionesLiberarPedido = a.ListadoAdjudicacionPedidoEntrega(con, IdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return OListadoLotesAdjudicacionesLiberarPedido;
            }
        }

        public List<beAdjudicacionLiberarPedido> ListadoAdjudicacionPedidoDetalle(int IdPedido)
        {
            List<beAdjudicacionLiberarPedido> OListadoLotesAdjudicacionesLiberarPedido = new List<beAdjudicacionLiberarPedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daAdjudicacionLiberarPedido a = new daAdjudicacionLiberarPedido();
                    OListadoLotesAdjudicacionesLiberarPedido = a.ListadoAdjudicacionPedidoDetalle(con, IdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return OListadoLotesAdjudicacionesLiberarPedido;
            }
        }

        public int GenerarPedidosAdjudicaciones_x_IdAdjudicacion(int IdAdjudicaciones)
        {
            int pedido = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    pedido = new daAdjudicacionLiberarPedido().GenerarPedidosAdjudicaciones_x_IdAdjudicacion(con, IdAdjudicaciones);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return pedido;
            }
        }

    }
}

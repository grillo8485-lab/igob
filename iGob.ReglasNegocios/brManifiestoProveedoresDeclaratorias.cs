using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brManifiestoProveedoresDeclaratorias : brConexion
    {
        public int guardarManifiestoProveedoresDeclaratorias(beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias)
        {
            int IdManifiestoProveedorDeclaratoria;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    IdManifiestoProveedorDeclaratoria = odaManifiestoProveedoresDeclaratorias.guardarManifiestoProveedoresDeclaratorias(con, obeManifiestoProveedoresDeclaratorias);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdManifiestoProveedorDeclaratoria;
            }
        }

        public int actualizarManifiestoProveedoresDeclaratorias(beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias)
        {
            int IdManifiestoProveedorDeclaratoria;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    IdManifiestoProveedorDeclaratoria = odaManifiestoProveedoresDeclaratorias.actualizarManifiestoProveedoresDeclaratorias(con, obeManifiestoProveedoresDeclaratorias);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdManifiestoProveedorDeclaratoria;
            }
        }

        public int eliminarManifiestoProveedoresDeclaratorias(int IdManifiestoProveedorDeclaratoria)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    IdManifiestoProveedorDeclaratoria = odaManifiestoProveedoresDeclaratorias.eliminarManifiestoProveedoresDeclaratorias(con, IdManifiestoProveedorDeclaratoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdManifiestoProveedorDeclaratoria;
            }
        }

        public beManifiestoProveedoresDeclaratorias traerManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedorDeclaratoria(int IdManifiestoProveedorDeclaratoria)
        {
            beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias = new beManifiestoProveedoresDeclaratorias();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    obeManifiestoProveedoresDeclaratorias = odaManifiestoProveedoresDeclaratorias.traerManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedorDeclaratoria(con, IdManifiestoProveedorDeclaratoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeManifiestoProveedoresDeclaratorias;
            }
        }

        public List<beManifiestoProveedoresDeclaratorias> listarTodos_ManifiestoProveedoresDeclaratorias()
        {
            List<beManifiestoProveedoresDeclaratorias> lbeManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    lbeManifiestoProveedoresDeclaratorias = odaManifiestoProveedoresDeclaratorias.listarTodos_ManifiestoProveedoresDeclaratorias(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
        public List<beManifiestoProveedoresDeclaratorias> listarTodos_ManifiestoProveedoresDeclaratorias_GetAll()
        {
            List<beManifiestoProveedoresDeclaratorias> lbeManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    lbeManifiestoProveedoresDeclaratorias = odaManifiestoProveedoresDeclaratorias.listar_ManifiestoProveedoresDeclaratorias_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }

        public List<beManifiestoProveedoresDeclaratorias> getAllManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedor(int pIdManifiestoProveedor)
        {
            List<beManifiestoProveedoresDeclaratorias> lbeManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    lbeManifiestoProveedoresDeclaratorias = odaManifiestoProveedoresDeclaratorias.getAllManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedor(con, pIdManifiestoProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
        public List<beManifiestoProveedoresDeclaratorias> getPedidoManifiestos_x_IdPedido(int pIdPedido)
        {
            List<beManifiestoProveedoresDeclaratorias> lbeManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    lbeManifiestoProveedoresDeclaratorias = odaManifiestoProveedoresDeclaratorias.getPedidoManifiestos_x_IdPedido(con, pIdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
        public List<bePedidoDetallesLotesEntregas> getPedidoDetallesLotesEntregas_x_IdPedido(int pIdPedido)
        {
            List<bePedidoDetallesLotesEntregas> lbeManifiestoProveedoresDeclaratorias = new List<bePedidoDetallesLotesEntregas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestoProveedoresDeclaratorias odaManifiestoProveedoresDeclaratorias = new daManifiestoProveedoresDeclaratorias();
                    lbeManifiestoProveedoresDeclaratorias = odaManifiestoProveedoresDeclaratorias.getPedidoDetallesLotesEntregas_x_IdPedido(con, pIdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
    }
}

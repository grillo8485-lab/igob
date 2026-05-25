using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brManifiestosProveedores : brConexion
    {
        public int guardarManifiestosProveedores(beManifiestosProveedores obeManifiestosProveedores)
        {
            int IdManifiestoProveedor;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestosProveedores odaManifiestosProveedores = new daManifiestosProveedores();
                    IdManifiestoProveedor = odaManifiestosProveedores.guardarManifiestosProveedores(con, obeManifiestosProveedores);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdManifiestoProveedor;
            }
        }

        public int actualizarManifiestosProveedores(beManifiestosProveedores obeManifiestosProveedores)
        {
            int IdManifiestoProveedor;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestosProveedores odaManifiestosProveedores = new daManifiestosProveedores();
                    IdManifiestoProveedor = odaManifiestosProveedores.actualizarManifiestosProveedores(con, obeManifiestosProveedores);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdManifiestoProveedor;
            }
        }

        public int eliminarManifiestosProveedores(int IdManifiestoProveedor)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestosProveedores odaManifiestosProveedores = new daManifiestosProveedores();
                    IdManifiestoProveedor = odaManifiestosProveedores.eliminarManifiestosProveedores(con, IdManifiestoProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdManifiestoProveedor;
            }
        }

        public beManifiestosProveedores traerManifiestosProveedores_x_IdManifiestoProveedor(int IdManifiestoProveedor)
        {
            beManifiestosProveedores obeManifiestosProveedores = new beManifiestosProveedores();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestosProveedores odaManifiestosProveedores = new daManifiestosProveedores();
                    obeManifiestosProveedores = odaManifiestosProveedores.traerManifiestosProveedores_x_IdManifiestoProveedor(con, IdManifiestoProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeManifiestosProveedores;
            }
        }

        public List<beManifiestosProveedores> listarTodos_ManifiestosProveedores()
        {
            List<beManifiestosProveedores> lbeManifiestosProveedores = new List<beManifiestosProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestosProveedores odaManifiestosProveedores = new daManifiestosProveedores();
                    lbeManifiestosProveedores = odaManifiestosProveedores.listarTodos_ManifiestosProveedores(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestosProveedores;
            }
        }
        public List<beManifiestosProveedores> listarTodos_ManifiestosProveedores_GetAll()
        {
            List<beManifiestosProveedores> lbeManifiestosProveedores = new List<beManifiestosProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestosProveedores odaManifiestosProveedores = new daManifiestosProveedores();
                    lbeManifiestosProveedores = odaManifiestosProveedores.listar_ManifiestosProveedores_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestosProveedores;
            }
        }
        public beManifiestosProveedores traerManifiestoProveedore_x_IdProveedorRqInvitacion(int pIdProveedorRqInvitacion)
        {
            beManifiestosProveedores lbeManifiestosProveedores = new beManifiestosProveedores();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daManifiestosProveedores odaManifiestosProveedores = new daManifiestosProveedores();
                    lbeManifiestosProveedores = odaManifiestosProveedores.traerManifiestoProveedore_x_IdProveedorRqInvitacion(con, pIdProveedorRqInvitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestosProveedores;
            }
        }
    }
}

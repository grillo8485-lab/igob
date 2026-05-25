using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brCondicionesPedidos : brConexion
    {
        public int guardarCondicionesPedidos(beCondicionesPedidos obeCondicionesPedidos)
        {
            int IdCondicionPedido;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCondicionesPedidos odaCondicionesPedidos = new daCondicionesPedidos();
                    IdCondicionPedido = odaCondicionesPedidos.guardarCondicionesPedidos(con, obeCondicionesPedidos);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCondicionPedido;
            }
        }

        public int actualizarCondicionesPedidos(beCondicionesPedidos obeCondicionesPedidos)
        {
            int IdCondicionPedido;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCondicionesPedidos odaCondicionesPedidos = new daCondicionesPedidos();
                    IdCondicionPedido = odaCondicionesPedidos.actualizarCondicionesPedidos(con, obeCondicionesPedidos);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCondicionPedido;
            }
        }

        public int eliminarCondicionesPedidos(int IdCondicionPedido)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCondicionesPedidos odaCondicionesPedidos = new daCondicionesPedidos();
                    IdCondicionPedido = odaCondicionesPedidos.eliminarCondicionesPedidos(con, IdCondicionPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCondicionPedido;
            }
        }

        public beCondicionesPedidos traerCondicionesPedidos_x_IdCondicionPedido(int IdCondicionPedido)
        {
            beCondicionesPedidos obeCondicionesPedidos = new beCondicionesPedidos();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCondicionesPedidos odaCondicionesPedidos = new daCondicionesPedidos();
                    obeCondicionesPedidos = odaCondicionesPedidos.traerCondicionesPedidos_x_IdCondicionPedido(con, IdCondicionPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeCondicionesPedidos;
            }
        }

        public List<beCondicionesPedidos> listarTodos_CondicionesPedidos()
        {
            List<beCondicionesPedidos> lbeCondicionesPedidos = new List<beCondicionesPedidos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCondicionesPedidos odaCondicionesPedidos = new daCondicionesPedidos();
                    lbeCondicionesPedidos = odaCondicionesPedidos.listarTodos_CondicionesPedidos(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCondicionesPedidos;
            }
        }
        public List<beCondicionesPedidos> listarTodos_CondicionesPedidos_GetAll()
        {
            List<beCondicionesPedidos> odtCondicionesPedidos = new List<beCondicionesPedidos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCondicionesPedidos odaCondicionesPedidos = new daCondicionesPedidos();
                    odtCondicionesPedidos = odaCondicionesPedidos.listar_CondicionesPedidos_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return odtCondicionesPedidos;
            }
        }
    }
}
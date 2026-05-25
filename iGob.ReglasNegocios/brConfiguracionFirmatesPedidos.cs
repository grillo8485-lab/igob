using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brConfiguracionFirmatesPedidos : brConexion
    {
        public int guardarConfiguracionFirmatesPedidos(beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos)
        {
            int IdConfigFirmantePedido;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionFirmatesPedidos odaConfiguracionFirmatesPedidos = new daConfiguracionFirmatesPedidos();
                    IdConfigFirmantePedido = odaConfiguracionFirmatesPedidos.guardarConfiguracionFirmatesPedidos(con, obeConfiguracionFirmatesPedidos);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfigFirmantePedido;
            }
        }

        public int actualizarConfiguracionFirmatesPedidos(beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos)
        {
            int IdConfigFirmantePedido;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionFirmatesPedidos odaConfiguracionFirmatesPedidos = new daConfiguracionFirmatesPedidos();
                    IdConfigFirmantePedido = odaConfiguracionFirmatesPedidos.actualizarConfiguracionFirmatesPedidos(con, obeConfiguracionFirmatesPedidos);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfigFirmantePedido;
            }
        }

        public int eliminarConfiguracionFirmatesPedidos(int IdConfigFirmantePedido)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionFirmatesPedidos odaConfiguracionFirmatesPedidos = new daConfiguracionFirmatesPedidos();
                    IdConfigFirmantePedido = odaConfiguracionFirmatesPedidos.eliminarConfiguracionFirmatesPedidos(con, IdConfigFirmantePedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfigFirmantePedido;
            }
        }

        public beConfiguracionFirmatesPedidos traerConfiguracionFirmatesPedidos_x_IdConfigFirmantePedido(int IdConfigFirmantePedido)
        {
            beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos = new beConfiguracionFirmatesPedidos();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionFirmatesPedidos odaConfiguracionFirmatesPedidos = new daConfiguracionFirmatesPedidos();
                    obeConfiguracionFirmatesPedidos = odaConfiguracionFirmatesPedidos.traerConfiguracionFirmatesPedidos_x_IdConfigFirmantePedido(con, IdConfigFirmantePedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionFirmatesPedidos;
            }
        }

        public List<beConfiguracionFirmatesPedidos> listarTodos_ConfiguracionFirmatesPedidos()
        {
            List<beConfiguracionFirmatesPedidos> lbeConfiguracionFirmatesPedidos = new List<beConfiguracionFirmatesPedidos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionFirmatesPedidos odaConfiguracionFirmatesPedidos = new daConfiguracionFirmatesPedidos();
                    lbeConfiguracionFirmatesPedidos = odaConfiguracionFirmatesPedidos.listarTodos_ConfiguracionFirmatesPedidos(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionFirmatesPedidos;
            }
        }
        public List<beConfiguracionFirmatesPedidos> listarTodos_ConfiguracionFirmatesPedidos_GetAll()
        {
            List<beConfiguracionFirmatesPedidos> lbeConfiguracionFirmatesPedidos = new List<beConfiguracionFirmatesPedidos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionFirmatesPedidos odaConfiguracionFirmatesPedidos = new daConfiguracionFirmatesPedidos();
                    lbeConfiguracionFirmatesPedidos = odaConfiguracionFirmatesPedidos.listar_ConfiguracionFirmatesPedidos_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionFirmatesPedidos;
            }
        }
        public List<beConfiguracionFirmatesPedidos> listarConfiguracionFirmantesModalidades_x_IdModalidadLicitacion(int pIdModalidadLicitacion)
        {
            List<beConfiguracionFirmatesPedidos> lbeConfiguracionFirmatesPedidos = new List<beConfiguracionFirmatesPedidos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionFirmatesPedidos odaConfiguracionFirmatesPedidos = new daConfiguracionFirmatesPedidos();
                    lbeConfiguracionFirmatesPedidos = odaConfiguracionFirmatesPedidos.listarConfiguracionFirmantesModalidades_x_IdModalidadLicitacion(con, pIdModalidadLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionFirmatesPedidos;
            }
        }
        public bool procesarOrdenamiento(int pIdModalidadLicitacion)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionFirmatesPedidos odaConfiguracionFirmatesPedidos = new daConfiguracionFirmatesPedidos();
                    result = odaConfiguracionFirmatesPedidos.procesarOrdenamiento(con, pIdModalidadLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
        }
    }
}

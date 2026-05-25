using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLicitaciones : brConexion
    {
        public int guardarLicitaciones(beLicitaciones obeLicitaciones)
        {
            int IdLicitacion;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitaciones odaLicitaciones = new daLicitaciones();
                    IdLicitacion = odaLicitaciones.guardarLicitaciones(con, obeLicitaciones);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLicitacion;
            }
        }

        public int actualizarLicitaciones(beLicitaciones obeLicitaciones)
        {
            int IdLicitacion;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitaciones odaLicitaciones = new daLicitaciones();
                    IdLicitacion = odaLicitaciones.actualizarLicitaciones(con, obeLicitaciones);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLicitacion;
            }
        }

        public int eliminarLicitaciones(int IdLicitacion)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitaciones odaLicitaciones = new daLicitaciones();
                    IdLicitacion = odaLicitaciones.eliminarLicitaciones(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLicitacion;
            }
        }

        public beLicitaciones traerLicitaciones_x_IdLicitacion(int IdLicitacion)
        {
            beLicitaciones obeLicitaciones = new beLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitaciones odaLicitaciones = new daLicitaciones();
                    obeLicitaciones = odaLicitaciones.traerLicitaciones_x_IdLicitacion(con, IdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitaciones> listarTodos_Licitaciones()
        {
            List<beLicitaciones> lbeLicitaciones = new List<beLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitaciones odaLicitaciones = new daLicitaciones();
                    lbeLicitaciones = odaLicitaciones.listarTodos_Licitaciones(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitaciones;
            }
        }
        public List<beLicitaciones> listarTodos_Licitaciones_GetAll()
        {
            List<beLicitaciones> lbeLicitaciones = new List<beLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitaciones odaLicitaciones = new daLicitaciones();
                    lbeLicitaciones = odaLicitaciones.listar_Licitaciones_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitaciones;
            }
        }
        public beLicitaciones traerLicitaciones_x_Fecha_IdGobierno(DateTime FechaAutorizcion, int IdGobierno, int IdTipoLicitacion, int IdTiempo, int IdModalidadLicitacion)
        {
            beLicitaciones obeLicitaciones = new beLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLicitaciones odaLicitaciones = new daLicitaciones();
                    obeLicitaciones = odaLicitaciones.traerLicitaciones_x_Fecha_IdGobierno(con, FechaAutorizcion, IdGobierno, IdTipoLicitacion, IdTiempo, IdModalidadLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }
        public beErrorProceso GenerarActaAdjudicacionProveedores(int pIdLicitacion)
        {
            beErrorProceso Success;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    
                    Success = (new daLicitaciones()).GenerarActaAdjudicacionProveedores(con, pIdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Success;
            }
        }
        public beErrorProceso GenerarPedidosLicitaciones_x_IdLicitacion(int pIdLicitacion)
        {
            beErrorProceso Success = new beErrorProceso();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    Success = (new daLicitaciones()).GenerarPedidosLicitaciones_x_IdLicitacion(con, pIdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Success;
            }
        }
        public beErrorProceso GenerarPedido_x_IdLicitacion(int pIdLicitacion)
        {
            beErrorProceso Success;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    Success = (new daLicitaciones()).GenerarPedido_x_IdLicitacion(con, pIdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Success;
            }
        }
        public beErrorProceso GenerarActaDictamen_Publicar_x_IdLicitacion(int pIdLicitacion, int pIdEstatusLicitacion)
        {
            beErrorProceso Success;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    Success = (new daLicitaciones()).GenerarActaDictamen_Publicar_x_IdLicitacion(con, pIdLicitacion, pIdEstatusLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Success;
            }
        }

        public beErrorProceso GenerarRequisionesSegundaLicitacion_x_IdLicitacion(int pIdLicitacion)
        {
            beErrorProceso Success;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    Success = (new daLicitaciones()).GenerarRequisionesSegundaLicitacion_x_IdLicitacion(con, pIdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Success;
            }
        }

    }
}

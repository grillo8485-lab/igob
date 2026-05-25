using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brModalidadesLicitaciones : brConexion
    {
        public int guardarModalidadesLicitaciones(beModalidadesLicitaciones obeModalidadesLicitaciones)
        {
            int IdModalidadLicitacion;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daModalidadesLicitaciones odaModalidadesLicitaciones = new daModalidadesLicitaciones();
                    IdModalidadLicitacion = odaModalidadesLicitaciones.guardarModalidadesLicitaciones(con, obeModalidadesLicitaciones);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdModalidadLicitacion;
            }
        }

        public int actualizarModalidadesLicitaciones(beModalidadesLicitaciones obeModalidadesLicitaciones)
        {
            int IdModalidadLicitacion;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daModalidadesLicitaciones odaModalidadesLicitaciones = new daModalidadesLicitaciones();
                    IdModalidadLicitacion = odaModalidadesLicitaciones.actualizarModalidadesLicitaciones(con, obeModalidadesLicitaciones);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdModalidadLicitacion;
            }
        }

        public int eliminarModalidadesLicitaciones(int IdModalidadLicitacion)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daModalidadesLicitaciones odaModalidadesLicitaciones = new daModalidadesLicitaciones();
                    IdModalidadLicitacion = odaModalidadesLicitaciones.eliminarModalidadesLicitaciones(con, IdModalidadLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdModalidadLicitacion;
            }
        }

        public beModalidadesLicitaciones traerModalidadesLicitaciones_x_IdModalidadLicitacion(int IdModalidadLicitacion)
        {
            beModalidadesLicitaciones obeModalidadesLicitaciones = new beModalidadesLicitaciones();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daModalidadesLicitaciones odaModalidadesLicitaciones = new daModalidadesLicitaciones();
                    obeModalidadesLicitaciones = odaModalidadesLicitaciones.traerModalidadesLicitaciones_x_IdModalidadLicitacion(con, IdModalidadLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeModalidadesLicitaciones;
            }
        }

        public List<beModalidadesLicitaciones> listarTodos_ModalidadesLicitaciones()
        {
            List<beModalidadesLicitaciones> lbeModalidadesLicitaciones = new List<beModalidadesLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daModalidadesLicitaciones odaModalidadesLicitaciones = new daModalidadesLicitaciones();
                    lbeModalidadesLicitaciones = odaModalidadesLicitaciones.listarTodos_ModalidadesLicitaciones(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeModalidadesLicitaciones;
            }
        }
        public List<beModalidadesLicitaciones> listarTodos_ModalidadesLicitaciones_GetAll()
        {
            List<beModalidadesLicitaciones> lbeModalidadesLicitaciones = new List<beModalidadesLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daModalidadesLicitaciones odaModalidadesLicitaciones = new daModalidadesLicitaciones();
                    lbeModalidadesLicitaciones = odaModalidadesLicitaciones.listar_ModalidadesLicitaciones_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeModalidadesLicitaciones;
            }
        }
        
    }
}

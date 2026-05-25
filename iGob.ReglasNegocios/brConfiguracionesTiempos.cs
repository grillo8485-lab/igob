using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brConfiguracionesTiempos : brConexion
    {
        public int guardarConfiguracionesTiempos(beConfiguracionesTiempos obeConfiguracionesTiempos)
        {
            int IdConfiguracionTiempo;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesTiempos odaConfiguracionesTiempos = new daConfiguracionesTiempos();
                    IdConfiguracionTiempo = odaConfiguracionesTiempos.guardarConfiguracionesTiempos(con, obeConfiguracionesTiempos);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionTiempo;
            }
        }

        public int actualizarConfiguracionesTiempos(beConfiguracionesTiempos obeConfiguracionesTiempos)
        {
            int IdConfiguracionTiempo;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesTiempos odaConfiguracionesTiempos = new daConfiguracionesTiempos();
                    IdConfiguracionTiempo = odaConfiguracionesTiempos.actualizarConfiguracionesTiempos(con, obeConfiguracionesTiempos);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionTiempo;
            }
        }

        public int eliminarConfiguracionesTiempos(int IdConfiguracionTiempo)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesTiempos odaConfiguracionesTiempos = new daConfiguracionesTiempos();
                    IdConfiguracionTiempo = odaConfiguracionesTiempos.eliminarConfiguracionesTiempos(con, IdConfiguracionTiempo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionTiempo;
            }
        }

        public beConfiguracionesTiempos traerConfiguracionesTiempos_x_IdConfiguracionTiempo(int IdConfiguracionTiempo)
        {
            beConfiguracionesTiempos obeConfiguracionesTiempos = new beConfiguracionesTiempos();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesTiempos odaConfiguracionesTiempos = new daConfiguracionesTiempos();
                    obeConfiguracionesTiempos = odaConfiguracionesTiempos.traerConfiguracionesTiempos_x_IdConfiguracionTiempo(con, IdConfiguracionTiempo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionesTiempos;
            }
        }

        public List<beConfiguracionesTiempos> listarTodos_ConfiguracionesTiempos()
        {
            List<beConfiguracionesTiempos> lbeConfiguracionesTiempos = new List<beConfiguracionesTiempos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesTiempos odaConfiguracionesTiempos = new daConfiguracionesTiempos();
                    lbeConfiguracionesTiempos = odaConfiguracionesTiempos.listarTodos_ConfiguracionesTiempos(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionesTiempos;
            }
        }
        public List<beConfiguracionesTiempos> listarTodos_ConfiguracionesTiempos_GetAll()
        {
            List<beConfiguracionesTiempos> odtConfiguracionesTiempos = new List<beConfiguracionesTiempos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesTiempos odaConfiguracionesTiempos = new daConfiguracionesTiempos();
                    odtConfiguracionesTiempos = odaConfiguracionesTiempos.listar_ConfiguracionesTiempos_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return odtConfiguracionesTiempos;
            }
        }
    }
}
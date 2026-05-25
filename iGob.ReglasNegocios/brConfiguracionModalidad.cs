using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brConfiguracionModalidad : brConexion
    {
        public int guardarConfiguracionModalidad(beConfiguracionModalidad obeConfiguracionModalidad)
        {
            int IdConfiguracionModalidad;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidad odaConfiguracionModalidad = new daConfiguracionModalidad();
                    IdConfiguracionModalidad = odaConfiguracionModalidad.guardarConfiguracionModalidad(con, obeConfiguracionModalidad);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidad;
            }
        }

        public int actualizarConfiguracionModalidad(beConfiguracionModalidad obeConfiguracionModalidad)
        {
            int IdConfiguracionModalidad;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidad odaConfiguracionModalidad = new daConfiguracionModalidad();
                    IdConfiguracionModalidad = odaConfiguracionModalidad.actualizarConfiguracionModalidad(con, obeConfiguracionModalidad);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidad;
            }
        }

        public int eliminarConfiguracionModalidad(int IdConfiguracionModalidad)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidad odaConfiguracionModalidad = new daConfiguracionModalidad();
                    IdConfiguracionModalidad = odaConfiguracionModalidad.eliminarConfiguracionModalidad(con, IdConfiguracionModalidad);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidad;
            }
        }

        public beConfiguracionModalidad traerConfiguracionModalidad_x_IdConfiguracionModalidad(int IdConfiguracionModalidad)
        {
            beConfiguracionModalidad obeConfiguracionModalidad = new beConfiguracionModalidad();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidad odaConfiguracionModalidad = new daConfiguracionModalidad();
                    obeConfiguracionModalidad = odaConfiguracionModalidad.traerConfiguracionModalidad_x_IdConfiguracionModalidad(con, IdConfiguracionModalidad);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionModalidad;
            }
        }

        public List<beConfiguracionModalidad> listarTodos_ConfiguracionModalidad()
        {
            List<beConfiguracionModalidad> lbeConfiguracionModalidad = new List<beConfiguracionModalidad>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidad odaConfiguracionModalidad = new daConfiguracionModalidad();
                    lbeConfiguracionModalidad = odaConfiguracionModalidad.listarTodos_ConfiguracionModalidad(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionModalidad;
            }
        }
        public List<beConfiguracionModalidad> listarTodos_ConfiguracionModalidad_GetAll()
        {
            List<beConfiguracionModalidad> odtConfiguracionModalidad = new List<beConfiguracionModalidad>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidad odaConfiguracionModalidad = new daConfiguracionModalidad();
                    odtConfiguracionModalidad = odaConfiguracionModalidad.listar_ConfiguracionModalidad_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return odtConfiguracionModalidad;
            }
        }
    }
}
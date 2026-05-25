using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brConfiguracionesModalidades : brConexion
    {
        public int guardarConfiguracionesModalidades(beConfiguracionesModalidades obeConfiguracionesModalidades)
        {
            int IdConfiguracionModalidad;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesModalidades odaConfiguracionesModalidades = new daConfiguracionesModalidades();
                    IdConfiguracionModalidad = odaConfiguracionesModalidades.guardarConfiguracionesModalidades(con, obeConfiguracionesModalidades);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidad;
            }
        }

        public int actualizarConfiguracionesModalidades(beConfiguracionesModalidades obeConfiguracionesModalidades)
        {
            int IdConfiguracionModalidad;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesModalidades odaConfiguracionesModalidades = new daConfiguracionesModalidades();
                    IdConfiguracionModalidad = odaConfiguracionesModalidades.actualizarConfiguracionesModalidades(con, obeConfiguracionesModalidades);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidad;
            }
        }

        public int eliminarConfiguracionesModalidades(int IdConfiguracionModalidad)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesModalidades odaConfiguracionesModalidades = new daConfiguracionesModalidades();
                    IdConfiguracionModalidad = odaConfiguracionesModalidades.eliminarConfiguracionesModalidades(con, IdConfiguracionModalidad);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidad;
            }
        }

        public beConfiguracionesModalidades traerConfiguracionesModalidades_x_IdConfiguracionModalidad(int IdConfiguracionModalidad)
        {
            beConfiguracionesModalidades obeConfiguracionesModalidades = new beConfiguracionesModalidades();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesModalidades odaConfiguracionesModalidades = new daConfiguracionesModalidades();
                    obeConfiguracionesModalidades = odaConfiguracionesModalidades.traerConfiguracionesModalidades_x_IdConfiguracionModalidad(con, IdConfiguracionModalidad);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionesModalidades;
            }
        }

        public List<beConfiguracionesModalidades> listarTodos_ConfiguracionesModalidades()
        {
            List<beConfiguracionesModalidades> lbeConfiguracionesModalidades = new List<beConfiguracionesModalidades>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesModalidades odaConfiguracionesModalidades = new daConfiguracionesModalidades();
                    lbeConfiguracionesModalidades = odaConfiguracionesModalidades.listarTodos_ConfiguracionesModalidades(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionesModalidades;
            }
        }
        public List<beConfiguracionesModalidades> listarTodos_ConfiguracionesModalidades_GetAll()
        {
            List<beConfiguracionesModalidades> lbeConfiguracionesModalidades = new List<beConfiguracionesModalidades>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesModalidades odaConfiguracionesModalidades = new daConfiguracionesModalidades();
                    lbeConfiguracionesModalidades = odaConfiguracionesModalidades.listar_ConfiguracionesModalidades_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionesModalidades;
            }
        }

        public List<beConfiguracionesModalidades> ConfiguracionesModalidades_traer_TiposLicitacion()
        {
            List<beConfiguracionesModalidades> odtConfiguracionModalidad = new List<beConfiguracionesModalidades>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionesModalidades odaConfiguracionModalidad = new daConfiguracionesModalidades();
                    odtConfiguracionModalidad = odaConfiguracionModalidad.ConfiguracionesModalidades_traer_TiposLicitacion(con);
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

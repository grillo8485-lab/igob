using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brConfiguracionModalidadTipoProceso : brConexion
    {



        public int guardarConfiguracionModalidadTipoProceso(beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso)
        {
            int IdConfiguracionModalidadTipoProceso;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidadTipoProceso odaConfiguracionModalidadTipoProceso = new daConfiguracionModalidadTipoProceso();
                    IdConfiguracionModalidadTipoProceso = odaConfiguracionModalidadTipoProceso.guardarConfiguracionModalidadTipoProceso(con, obeConfiguracionModalidadTipoProceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidadTipoProceso;
            }
        }

        public int actualizarConfiguracionModalidadTipoProceso(beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso)
        {
            int IdConfiguracionModalidadTipoProceso;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidadTipoProceso odaConfiguracionModalidadTipoProceso = new daConfiguracionModalidadTipoProceso();
                    IdConfiguracionModalidadTipoProceso = odaConfiguracionModalidadTipoProceso.actualizarConfiguracionModalidadTipoProceso(con, obeConfiguracionModalidadTipoProceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidadTipoProceso;
            }
        }

        public int eliminarConfiguracionModalidadTipoProceso(int IdConfiguracionModalidadTipoProceso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidadTipoProceso odaConfiguracionModalidadTipoProceso = new daConfiguracionModalidadTipoProceso();
                    IdConfiguracionModalidadTipoProceso = odaConfiguracionModalidadTipoProceso.eliminarConfiguracionModalidadTipoProceso(con, IdConfiguracionModalidadTipoProceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdConfiguracionModalidadTipoProceso;
            }
        }

        public beConfiguracionModalidadTipoProceso traerConfiguracionModalidadTipoProceso_x_IdConfiguracionModalidadTipoProceso(int IdConfiguracionModalidadTipoProceso)
        {
            beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso = new beConfiguracionModalidadTipoProceso();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidadTipoProceso odaConfiguracionModalidadTipoProceso = new daConfiguracionModalidadTipoProceso();
                    obeConfiguracionModalidadTipoProceso = odaConfiguracionModalidadTipoProceso.traerConfiguracionModalidadTipoProceso_x_IdConfiguracionModalidadTipoProceso(con, IdConfiguracionModalidadTipoProceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionModalidadTipoProceso;
            }
        }

        public List<beConfiguracionModalidadTipoProceso> listarTodos_ConfiguracionModalidadTipoProceso()
        {
            List<beConfiguracionModalidadTipoProceso> lbeConfiguracionModalidadTipoProceso = new List<beConfiguracionModalidadTipoProceso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidadTipoProceso odaConfiguracionModalidadTipoProceso = new daConfiguracionModalidadTipoProceso();
                    lbeConfiguracionModalidadTipoProceso = odaConfiguracionModalidadTipoProceso.listarTodos_ConfiguracionModalidadTipoProceso(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionModalidadTipoProceso;
            }
        }
        public List<beConfiguracionModalidadTipoProceso> listarTodos_ConfiguracionModalidadTipoProceso_GetAll()
        {
            List<beConfiguracionModalidadTipoProceso> lbeConfiguracionModalidadTipoProceso = new List<beConfiguracionModalidadTipoProceso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidadTipoProceso odaConfiguracionModalidadTipoProceso = new daConfiguracionModalidadTipoProceso();
                    lbeConfiguracionModalidadTipoProceso = odaConfiguracionModalidadTipoProceso.listar_ConfiguracionModalidadTipoProceso_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionModalidadTipoProceso;
            }
        }

        public beConfiguracionModalidadTipoProceso getConfiguracionModalidadTipoProceso_x_IdModalidadLicitacion(int pIdModalidadLicitacion)
        {
            beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso = new beConfiguracionModalidadTipoProceso();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConfiguracionModalidadTipoProceso odaConfiguracionModalidadTipoProceso = new daConfiguracionModalidadTipoProceso();
                    obeConfiguracionModalidadTipoProceso = odaConfiguracionModalidadTipoProceso.getConfiguracionModalidadTipoProceso_x_IdModalidadLicitacion(con, pIdModalidadLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionModalidadTipoProceso;
            }
        }
    }
}

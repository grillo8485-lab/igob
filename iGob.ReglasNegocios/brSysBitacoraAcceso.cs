using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SoftHomeDeco.Entidades;
using SoftHomeDeco.AccesoDatos;
using iGob.ReglasNegocios;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace SoftHomeDeco.ReglasNegocios
{
    public class brSysBitacoraAcceso : brConexion
    {
        public int guardarSysBitacoraAcceso(beSysBitacoraAcceso obeSysBitacoraAcceso)
        {
            int IdAcceso = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysBitacoraAcceso odaSysBitacoraAcceso = new daSysBitacoraAcceso();
                    IdAcceso = odaSysBitacoraAcceso.guardarSysBitacoraAcceso(con, obeSysBitacoraAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdAcceso;
            }
        }

        public int actualizarSysBitacoraAcceso(beSysBitacoraAcceso obeSysBitacoraAcceso)
        {
            int IdAcceso;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysBitacoraAcceso odaSysBitacoraAcceso = new daSysBitacoraAcceso();
                    IdAcceso = odaSysBitacoraAcceso.actualizarSysBitacoraAcceso(con, obeSysBitacoraAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdAcceso;
            }
        }

        public int eliminarSysBitacoraAcceso(int IdAcceso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysBitacoraAcceso odaSysBitacoraAcceso = new daSysBitacoraAcceso();
                    IdAcceso = odaSysBitacoraAcceso.eliminarSysBitacoraAcceso(con, IdAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdAcceso;
            }
        }

        public beSysBitacoraAcceso traerSysBitacoraAcceso_x_IdAcceso(int IdAcceso)
        {
            beSysBitacoraAcceso obeSysBitacoraAcceso = new beSysBitacoraAcceso();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysBitacoraAcceso odaSysBitacoraAcceso = new daSysBitacoraAcceso();
                    obeSysBitacoraAcceso = odaSysBitacoraAcceso.traerSysBitacoraAcceso_x_IdAcceso(con, IdAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeSysBitacoraAcceso;
            }
        }

        public List<beSysBitacoraAcceso> listarTodos_SysBitacoraAcceso()
        {
            List<beSysBitacoraAcceso> lbeSysBitacoraAcceso = new List<beSysBitacoraAcceso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysBitacoraAcceso odaSysBitacoraAcceso = new daSysBitacoraAcceso();
                    lbeSysBitacoraAcceso = odaSysBitacoraAcceso.listarTodos_SysBitacoraAcceso(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeSysBitacoraAcceso;
            }
        }
        public beSysBitacoraAcceso traerSysBitacoraAcceso_x_LlaveAcceso(string pLlaveAcceso)
        {
            beSysBitacoraAcceso obeSysBitacoraAcceso = new beSysBitacoraAcceso();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysBitacoraAcceso odaSysBitacoraAcceso = new daSysBitacoraAcceso();
                    obeSysBitacoraAcceso = odaSysBitacoraAcceso.traerSysBitacoraAcceso_x_LlaveAcceso(con, pLlaveAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeSysBitacoraAcceso;
            }
        }
    }
}

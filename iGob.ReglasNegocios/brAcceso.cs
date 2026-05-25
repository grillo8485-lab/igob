using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brAcceso : brConexion
    {
        public int guardarAcceso(beAcceso obeAcceso)
        {
            int IdAcceso;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAcceso odaAcceso = new daAcceso();
                    IdAcceso = odaAcceso.guardarAcceso(con, obeAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdAcceso;
            }
        }

        public int actualizarAcceso(beAcceso obeAcceso)
        {
            int IdAcceso;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAcceso odaAcceso = new daAcceso();
                    IdAcceso = odaAcceso.actualizarAcceso(con, obeAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdAcceso;
            }
        }

        public int eliminarAcceso(int IdAcceso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAcceso odaAcceso = new daAcceso();
                    IdAcceso = odaAcceso.eliminarAcceso(con, IdAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdAcceso;
            }
        }

        public beAcceso traerAcceso_x_IdAcceso(int IdAcceso)
        {
            beAcceso obeAcceso = new beAcceso();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAcceso odaAcceso = new daAcceso();
                    obeAcceso = odaAcceso.traerAcceso_x_IdAcceso(con, IdAcceso);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAcceso;
            }
        }

        public List<beAcceso> listarTodos_Acceso()
        {
            List<beAcceso> lbeAcceso = new List<beAcceso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAcceso odaAcceso = new daAcceso();
                    lbeAcceso = odaAcceso.listarTodos_Acceso(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAcceso;
            }
        }
        public List<beAcceso> listarTodos_Acceso_GetAll()
        {
            List<beAcceso> lbeAcceso = new List<beAcceso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAcceso odaAcceso = new daAcceso();
                    lbeAcceso = odaAcceso.listar_Acceso_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAcceso;
            }
        }
        public int setPaswword()
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAcceso odaAcceso = new daAcceso();
                    result = odaAcceso.setPaswword(con);
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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brTokenHistorial : brConexion
    {
        public int guardarTokenHistorial(beTokenHistorial obeTokenHistorial)
        {
            int IdTokenHistorial;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTokenHistorial odaTokenHistorial = new daTokenHistorial();
                    IdTokenHistorial = odaTokenHistorial.guardarTokenHistorial(con, obeTokenHistorial);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdTokenHistorial;
            }
        }

        public int actualizarTokenHistorial(beTokenHistorial obeTokenHistorial)
        {
            int IdTokenHistorial;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTokenHistorial odaTokenHistorial = new daTokenHistorial();
                    IdTokenHistorial = odaTokenHistorial.actualizarTokenHistorial(con, obeTokenHistorial);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdTokenHistorial;
            }
        }

        public int eliminarTokenHistorial(int IdTokenHistorial)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTokenHistorial odaTokenHistorial = new daTokenHistorial();
                    IdTokenHistorial = odaTokenHistorial.eliminarTokenHistorial(con, IdTokenHistorial);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdTokenHistorial;
            }
        }

        public beTokenHistorial traerTokenHistorial_x_IdTokenHistorial(int IdTokenHistorial)
        {
            beTokenHistorial obeTokenHistorial = new beTokenHistorial();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTokenHistorial odaTokenHistorial = new daTokenHistorial();
                    obeTokenHistorial = odaTokenHistorial.traerTokenHistorial_x_IdTokenHistorial(con, IdTokenHistorial);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeTokenHistorial;
            }
        }

        public List<beTokenHistorial> listarTodos_TokenHistorial()
        {
            List<beTokenHistorial> lbeTokenHistorial = new List<beTokenHistorial>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTokenHistorial odaTokenHistorial = new daTokenHistorial();
                    lbeTokenHistorial = odaTokenHistorial.listarTodos_TokenHistorial(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTokenHistorial;
            }
        }
        public List<beTokenHistorial> listarTodos_TokenHistorial_GetAll()
        {
            List<beTokenHistorial> lbeTokenHistorial = new List<beTokenHistorial>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTokenHistorial odaTokenHistorial = new daTokenHistorial();
                    lbeTokenHistorial = odaTokenHistorial.listar_TokenHistorial_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTokenHistorial;
            }
        }
        public beTokenHistorial traerTokenHistorial_x_Token(string Token)
        {
            beTokenHistorial obeTokenHistorial = new beTokenHistorial();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTokenHistorial odaTokenHistorial = new daTokenHistorial();
                    obeTokenHistorial = odaTokenHistorial.traerTokenHistorial_x_Token(con, Token);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeTokenHistorial;
            }
        }
        //traerTokenHistorial_x_Token
    }
}

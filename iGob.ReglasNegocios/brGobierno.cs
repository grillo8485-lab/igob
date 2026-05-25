using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brGobierno : brConexion
    {
        public int guardarGobierno(beGobierno obeGobierno)
        {
            int IdGobierno;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGobierno odaGobierno = new daGobierno();
                    IdGobierno = odaGobierno.guardarGobierno(con, obeGobierno);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdGobierno;
            }
        }

        public int actualizarGobierno(beGobierno obeGobierno)
        {
            int IdGobierno;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGobierno odaGobierno = new daGobierno();
                    IdGobierno = odaGobierno.actualizarGobierno(con, obeGobierno);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdGobierno;
            }
        }

        public int eliminarGobierno(int IdGobierno)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGobierno odaGobierno = new daGobierno();
                    IdGobierno = odaGobierno.eliminarGobierno(con, IdGobierno);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdGobierno;
            }
        }

        public beGobierno traerGobierno_x_IdGobierno(int IdGobierno)
        {
            beGobierno obeGobierno = new beGobierno();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGobierno odaGobierno = new daGobierno();
                    obeGobierno = odaGobierno.traerGobierno_x_IdGobierno(con, IdGobierno);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeGobierno;
            }
        }

        public List<beGobierno> listarTodos_Gobierno()
        {
            List<beGobierno> lbeGobierno = new List<beGobierno>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGobierno odaGobierno = new daGobierno();
                    lbeGobierno = odaGobierno.listarTodos_Gobierno(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeGobierno;
            }
        }
        public List<beGobierno> listarTodos_Gobierno_GetAll()
        {
            List<beGobierno> odtGobierno = new List<beGobierno>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGobierno odaGobierno = new daGobierno();
                    odtGobierno = odaGobierno.listar_Gobierno_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return odtGobierno;
            }
        }
    }
}
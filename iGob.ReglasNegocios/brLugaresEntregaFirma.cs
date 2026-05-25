using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brLugaresEntregaFirma : brConexion
    {
        public int guardarLugaresEntregaFirma(beLugaresEntregaFirma obeLugaresEntregaFirma)
        {
            int IdLugarEntregaFirma;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregaFirma odaLugaresEntregaFirma = new daLugaresEntregaFirma();
                    IdLugarEntregaFirma = odaLugaresEntregaFirma.guardarLugaresEntregaFirma(con, obeLugaresEntregaFirma);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLugarEntregaFirma;
            }
        }

        public int actualizarLugaresEntregaFirma(beLugaresEntregaFirma obeLugaresEntregaFirma)
        {
            int IdLugarEntregaFirma;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregaFirma odaLugaresEntregaFirma = new daLugaresEntregaFirma();
                    IdLugarEntregaFirma = odaLugaresEntregaFirma.actualizarLugaresEntregaFirma(con, obeLugaresEntregaFirma);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLugarEntregaFirma;
            }
        }

        public int eliminarLugaresEntregaFirma(int IdLugarEntregaFirma)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregaFirma odaLugaresEntregaFirma = new daLugaresEntregaFirma();
                    IdLugarEntregaFirma = odaLugaresEntregaFirma.eliminarLugaresEntregaFirma(con, IdLugarEntregaFirma);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLugarEntregaFirma;
            }
        }

        public beLugaresEntregaFirma traerLugaresEntregaFirma_x_IdLugarEntregaFirma(int IdLugarEntregaFirma)
        {
            beLugaresEntregaFirma obeLugaresEntregaFirma = new beLugaresEntregaFirma();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregaFirma odaLugaresEntregaFirma = new daLugaresEntregaFirma();
                    obeLugaresEntregaFirma = odaLugaresEntregaFirma.traerLugaresEntregaFirma_x_IdLugarEntregaFirma(con, IdLugarEntregaFirma);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLugaresEntregaFirma;
            }
        }

        public List<beLugaresEntregaFirma> listarTodos_LugaresEntregaFirma()
        {
            List<beLugaresEntregaFirma> lbeLugaresEntregaFirma = new List<beLugaresEntregaFirma>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregaFirma odaLugaresEntregaFirma = new daLugaresEntregaFirma();
                    lbeLugaresEntregaFirma = odaLugaresEntregaFirma.listarTodos_LugaresEntregaFirma(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregaFirma;
            }
        }

        public List<beLugaresEntregaFirma> Listar_LugaresEntregaFirma_Traer_Entrega()
        {
            List<beLugaresEntregaFirma> lbeLugaresEntregaFirma = new List<beLugaresEntregaFirma>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregaFirma odaLugaresEntregaFirma = new daLugaresEntregaFirma();
                    lbeLugaresEntregaFirma = odaLugaresEntregaFirma.Listar_LugaresEntregaFirma_Traer_Entrega(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregaFirma;
            }
        }

        public List<beLugaresEntregaFirma> Listar_LugaresEntregaFirma_Traer_Firma()
        {
            List<beLugaresEntregaFirma> lbeLugaresEntregaFirma = new List<beLugaresEntregaFirma>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLugaresEntregaFirma odaLugaresEntregaFirma = new daLugaresEntregaFirma();
                    lbeLugaresEntregaFirma = odaLugaresEntregaFirma.Listar_LugaresEntregaFirma_Traer_Firma(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregaFirma;
            }
        }
    }
}

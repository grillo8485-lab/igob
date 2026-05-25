using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brEjerciciosFiscales : brConexion
    {
        public int guardarEjerciciosFiscales(beEjerciciosFiscales obeEjerciciosFiscales)
        {
            int IdEjercicioFiscal;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEjerciciosFiscales odaEjerciciosFiscales = new daEjerciciosFiscales();
                    IdEjercicioFiscal = odaEjerciciosFiscales.guardarEjerciciosFiscales(con, obeEjerciciosFiscales);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdEjercicioFiscal;
            }
        }

        public int actualizarEjerciciosFiscales(beEjerciciosFiscales obeEjerciciosFiscales)
        {
            int IdEjercicioFiscal;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEjerciciosFiscales odaEjerciciosFiscales = new daEjerciciosFiscales();
                    IdEjercicioFiscal = odaEjerciciosFiscales.actualizarEjerciciosFiscales(con, obeEjerciciosFiscales);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdEjercicioFiscal;
            }
        }

        public int eliminarEjerciciosFiscales(int IdEjercicioFiscal)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEjerciciosFiscales odaEjerciciosFiscales = new daEjerciciosFiscales();
                    IdEjercicioFiscal = odaEjerciciosFiscales.eliminarEjerciciosFiscales(con, IdEjercicioFiscal);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdEjercicioFiscal;
            }
        }

        public beEjerciciosFiscales traerEjerciciosFiscales_x_IdEjercicioFiscal(int IdEjercicioFiscal)
        {
            beEjerciciosFiscales obeEjerciciosFiscales = new beEjerciciosFiscales();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEjerciciosFiscales odaEjerciciosFiscales = new daEjerciciosFiscales();
                    obeEjerciciosFiscales = odaEjerciciosFiscales.traerEjerciciosFiscales_x_IdEjercicioFiscal(con, IdEjercicioFiscal);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeEjerciciosFiscales;
            }
        }

        public List<beEjerciciosFiscales> listarTodos_EjerciciosFiscales()
        {
            List<beEjerciciosFiscales> lbeEjerciciosFiscales = new List<beEjerciciosFiscales>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEjerciciosFiscales odaEjerciciosFiscales = new daEjerciciosFiscales();
                    lbeEjerciciosFiscales = odaEjerciciosFiscales.listarTodos_EjerciciosFiscales(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeEjerciciosFiscales;
            }
        }

    }
}

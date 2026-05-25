using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brDatosPersonas : brConexion
    {
        public int guardarDatosPersonas(beDatosPersonas obeDatosPersonas)
        {
            int IdPersona;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosPersonas odaDatosPersonas = new daDatosPersonas();
                    IdPersona = odaDatosPersonas.guardarDatosPersonas(con, obeDatosPersonas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdPersona;
            }
        }

        public int actualizarDatosPersonas(beDatosPersonas obeDatosPersonas)
        {
            int IdPersona;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosPersonas odaDatosPersonas = new daDatosPersonas();
                    IdPersona = odaDatosPersonas.actualizarDatosPersonas(con, obeDatosPersonas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdPersona;
            }
        }

        public int eliminarDatosPersonas(int IdPersona)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosPersonas odaDatosPersonas = new daDatosPersonas();
                    IdPersona = odaDatosPersonas.eliminarDatosPersonas(con, IdPersona);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdPersona;
            }
        }

        public beDatosPersonas traerDatosPersonas_x_IdPersona(int IdPersona)
        {
            beDatosPersonas obeDatosPersonas = new beDatosPersonas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosPersonas odaDatosPersonas = new daDatosPersonas();
                    obeDatosPersonas = odaDatosPersonas.traerDatosPersonas_x_IdPersona(con, IdPersona);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeDatosPersonas;
            }
        }

        public List<beDatosPersonas> listarTodos_DatosPersonas()
        {
            List<beDatosPersonas> lbeDatosPersonas = new List<beDatosPersonas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosPersonas odaDatosPersonas = new daDatosPersonas();
                    lbeDatosPersonas = odaDatosPersonas.listarTodos_DatosPersonas(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDatosPersonas;
            }
        }
        public List<beDatosPersonas> listarTodos_DatosPersonas_GetAll()
        {
            List<beDatosPersonas> lbeDatosPersonas = new List<beDatosPersonas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosPersonas odaDatosPersonas = new daDatosPersonas();
                    lbeDatosPersonas = odaDatosPersonas.listar_DatosPersonas_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDatosPersonas;
            }
        }

        public List<beDatosPersonas> listarTodos_DatosPersonas_x_RfcNombreCompleto(string rfcNombreCompleto)
        {
            List<beDatosPersonas> lbeDatosPersonas = new List<beDatosPersonas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosPersonas odaDatosPersonas = new daDatosPersonas();
                    lbeDatosPersonas = odaDatosPersonas.listarTodos_DatosPersonas_x_RfcNombreCompleto(con, rfcNombreCompleto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDatosPersonas;
            }
        }
    }
}

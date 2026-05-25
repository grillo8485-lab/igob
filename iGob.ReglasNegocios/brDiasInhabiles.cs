using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brDiasInhabiles : brConexion
    {
        public int guardarDiasInhabiles(beDiasInhabiles obeDiasInhabiles)
        {
            int IdDiaInhabil;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDiasInhabiles odaDiasInhabiles = new daDiasInhabiles();
                    IdDiaInhabil = odaDiasInhabiles.guardarDiasInhabiles(con, obeDiasInhabiles);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdDiaInhabil;
            }
        }

        public int actualizarDiasInhabiles(beDiasInhabiles obeDiasInhabiles)
        {
            int IdDiaInhabil;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDiasInhabiles odaDiasInhabiles = new daDiasInhabiles();
                    IdDiaInhabil = odaDiasInhabiles.actualizarDiasInhabiles(con, obeDiasInhabiles);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdDiaInhabil;
            }
        }

        public int eliminarDiasInhabiles(int IdDiaInhabil)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDiasInhabiles odaDiasInhabiles = new daDiasInhabiles();
                    IdDiaInhabil = odaDiasInhabiles.eliminarDiasInhabiles(con, IdDiaInhabil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdDiaInhabil;
            }
        }

        public beDiasInhabiles traerDiasInhabiles_x_IdDiaInhabil(int IdDiaInhabil)
        {
            beDiasInhabiles obeDiasInhabiles = new beDiasInhabiles();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDiasInhabiles odaDiasInhabiles = new daDiasInhabiles();
                    obeDiasInhabiles = odaDiasInhabiles.traerDiasInhabiles_x_IdDiaInhabil(con, IdDiaInhabil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeDiasInhabiles;
            }
        }

        public List<beDiasInhabiles> listarTodos_DiasInhabiles()
        {
            List<beDiasInhabiles> lbeDiasInhabiles = new List<beDiasInhabiles>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDiasInhabiles odaDiasInhabiles = new daDiasInhabiles();
                    lbeDiasInhabiles = odaDiasInhabiles.listarTodos_DiasInhabiles(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDiasInhabiles;
            }
        }
        public List<beDiasInhabiles> listarTodos_DiasInhabiles_GetAll()
        {
            List<beDiasInhabiles> odtDiasInhabiles = new List<beDiasInhabiles>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDiasInhabiles odaDiasInhabiles = new daDiasInhabiles();
                    odtDiasInhabiles = odaDiasInhabiles.listar_DiasInhabiles_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return odtDiasInhabiles;
            }
        }
    }
}
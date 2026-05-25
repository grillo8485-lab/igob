using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesLiquidez:brConexion
		 {
	public int guardarAdjudicacionesLiquidez(beAdjudicacionesLiquidez obeAdjudicacionesLiquidez)
	{
		int IdAdjudicacionLiquidez;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesLiquidez odaAdjudicacionesLiquidez= new daAdjudicacionesLiquidez();
			IdAdjudicacionLiquidez =  odaAdjudicacionesLiquidez.guardarAdjudicacionesLiquidez(con, obeAdjudicacionesLiquidez);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionLiquidez;
			}
	}

	public int actualizarAdjudicacionesLiquidez(beAdjudicacionesLiquidez obeAdjudicacionesLiquidez)
	{
		int IdAdjudicacionLiquidez;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLiquidez odaAdjudicacionesLiquidez= new daAdjudicacionesLiquidez();
				IdAdjudicacionLiquidez =  odaAdjudicacionesLiquidez.actualizarAdjudicacionesLiquidez(con, obeAdjudicacionesLiquidez);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionLiquidez;
			}
	}

	public int eliminarAdjudicacionesLiquidez(int IdAdjudicacionLiquidez)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLiquidez odaAdjudicacionesLiquidez= new daAdjudicacionesLiquidez();
				IdAdjudicacionLiquidez =  odaAdjudicacionesLiquidez.eliminarAdjudicacionesLiquidez(con, IdAdjudicacionLiquidez);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionLiquidez;
			}
	}

	public beAdjudicacionesLiquidez traerAdjudicacionesLiquidez_x_IdAdjudicacionLiquidez (int IdAdjudicacionLiquidez)
	{
		beAdjudicacionesLiquidez obeAdjudicacionesLiquidez=new beAdjudicacionesLiquidez();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLiquidez odaAdjudicacionesLiquidez= new daAdjudicacionesLiquidez();
				 obeAdjudicacionesLiquidez =  odaAdjudicacionesLiquidez.traerAdjudicacionesLiquidez_x_IdAdjudicacionLiquidez(con, IdAdjudicacionLiquidez);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesLiquidez;
			}
	}

	public List<beAdjudicacionesLiquidez> listarTodos_AdjudicacionesLiquidez()
	 {
		List<beAdjudicacionesLiquidez> lbeAdjudicacionesLiquidez =new List<beAdjudicacionesLiquidez>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLiquidez odaAdjudicacionesLiquidez= new daAdjudicacionesLiquidez();
				 lbeAdjudicacionesLiquidez =  odaAdjudicacionesLiquidez.listarTodos_AdjudicacionesLiquidez(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLiquidez;
		}
	}
	public List<beAdjudicacionesLiquidez> listarTodos_AdjudicacionesLiquidez_GetAll()
	 {
		List<beAdjudicacionesLiquidez> lbeAdjudicacionesLiquidez =new List<beAdjudicacionesLiquidez>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLiquidez odaAdjudicacionesLiquidez= new daAdjudicacionesLiquidez();
				 lbeAdjudicacionesLiquidez =  odaAdjudicacionesLiquidez.listar_AdjudicacionesLiquidez_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLiquidez;
		}
	}

    public List<beAdjudicacionesLiquidez> AdjudicacionLiquidez_Traer_IdAdjudicacion(int IdAdjudicacion)
    {
        List<beAdjudicacionesLiquidez> lbeAdjudicacionesLiquidez = new List<beAdjudicacionesLiquidez>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daAdjudicacionesLiquidez odaAdjudicacionesLiquidez = new daAdjudicacionesLiquidez();
                    lbeAdjudicacionesLiquidez = odaAdjudicacionesLiquidez.AdjudicacionesLiquidez_Traer_IdAdjudicacion(con, IdAdjudicacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeAdjudicacionesLiquidez;
        }
    }
    }
}

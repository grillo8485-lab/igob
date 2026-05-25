using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesLugaresFirmas:brConexion
		 {
	public int guardarAdjudicacionesLugaresFirmas(beAdjudicacionesLugaresFirmas obeAdjudicacionesLugaresFirmas)
	{
		int IdAdjudicacionLugarFirma;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesLugaresFirmas odaAdjudicacionesLugaresFirmas= new daAdjudicacionesLugaresFirmas();
			IdAdjudicacionLugarFirma =  odaAdjudicacionesLugaresFirmas.guardarAdjudicacionesLugaresFirmas(con, obeAdjudicacionesLugaresFirmas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionLugarFirma;
			}
	}

	public int actualizarAdjudicacionesLugaresFirmas(beAdjudicacionesLugaresFirmas obeAdjudicacionesLugaresFirmas)
	{
		int IdAdjudicacionLugarFirma;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLugaresFirmas odaAdjudicacionesLugaresFirmas= new daAdjudicacionesLugaresFirmas();
				IdAdjudicacionLugarFirma =  odaAdjudicacionesLugaresFirmas.actualizarAdjudicacionesLugaresFirmas(con, obeAdjudicacionesLugaresFirmas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionLugarFirma;
			}
	}

	public int eliminarAdjudicacionesLugaresFirmas(int IdAdjudicacionLugarFirma)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLugaresFirmas odaAdjudicacionesLugaresFirmas= new daAdjudicacionesLugaresFirmas();
				IdAdjudicacionLugarFirma =  odaAdjudicacionesLugaresFirmas.eliminarAdjudicacionesLugaresFirmas(con, IdAdjudicacionLugarFirma);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionLugarFirma;
			}
	}

	public beAdjudicacionesLugaresFirmas traerAdjudicacionesLugaresFirmas_x_IdAdjudicacionLugarFirma (int IdAdjudicacionLugarFirma)
	{
		beAdjudicacionesLugaresFirmas obeAdjudicacionesLugaresFirmas=new beAdjudicacionesLugaresFirmas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLugaresFirmas odaAdjudicacionesLugaresFirmas= new daAdjudicacionesLugaresFirmas();
				 obeAdjudicacionesLugaresFirmas =  odaAdjudicacionesLugaresFirmas.traerAdjudicacionesLugaresFirmas_x_IdAdjudicacionLugarFirma(con, IdAdjudicacionLugarFirma);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesLugaresFirmas;
			}
	}

	public List<beAdjudicacionesLugaresFirmas> listarTodos_AdjudicacionesLugaresFirmas()
	 {
		List<beAdjudicacionesLugaresFirmas> lbeAdjudicacionesLugaresFirmas =new List<beAdjudicacionesLugaresFirmas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLugaresFirmas odaAdjudicacionesLugaresFirmas= new daAdjudicacionesLugaresFirmas();
				 lbeAdjudicacionesLugaresFirmas =  odaAdjudicacionesLugaresFirmas.listarTodos_AdjudicacionesLugaresFirmas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLugaresFirmas;
		}
	}
	public List<beAdjudicacionesLugaresFirmas> listarTodos_AdjudicacionesLugaresFirmas_GetAll()
	 {
		List<beAdjudicacionesLugaresFirmas> lbeAdjudicacionesLugaresFirmas =new List<beAdjudicacionesLugaresFirmas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLugaresFirmas odaAdjudicacionesLugaresFirmas= new daAdjudicacionesLugaresFirmas();
				 lbeAdjudicacionesLugaresFirmas =  odaAdjudicacionesLugaresFirmas.listar_AdjudicacionesLugaresFirmas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLugaresFirmas;
		}
	}
}
}

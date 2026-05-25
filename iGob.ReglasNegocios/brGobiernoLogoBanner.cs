using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brGobiernoLogoBanner:brConexion
		 {
	public int guardarGobiernoLogoBanner(beGobiernoLogoBanner obeGobiernoLogoBanner)
	{
		int IdLogoBanner;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daGobiernoLogoBanner odaGobiernoLogoBanner= new daGobiernoLogoBanner();
			IdLogoBanner =  odaGobiernoLogoBanner.guardarGobiernoLogoBanner(con, obeGobiernoLogoBanner);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdLogoBanner;
			}
	}

	public int actualizarGobiernoLogoBanner(beGobiernoLogoBanner obeGobiernoLogoBanner)
	{
		int IdLogoBanner;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daGobiernoLogoBanner odaGobiernoLogoBanner= new daGobiernoLogoBanner();
				IdLogoBanner =  odaGobiernoLogoBanner.actualizarGobiernoLogoBanner(con, obeGobiernoLogoBanner);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdLogoBanner;
			}
	}

	public int eliminarGobiernoLogoBanner(int IdLogoBanner)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daGobiernoLogoBanner odaGobiernoLogoBanner= new daGobiernoLogoBanner();
				IdLogoBanner =  odaGobiernoLogoBanner.eliminarGobiernoLogoBanner(con, IdLogoBanner);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdLogoBanner;
			}
	}

	public beGobiernoLogoBanner traerGobiernoLogoBanner_x_IdLogoBanner (int IdLogoBanner)
	{
		beGobiernoLogoBanner obeGobiernoLogoBanner=new beGobiernoLogoBanner();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daGobiernoLogoBanner odaGobiernoLogoBanner= new daGobiernoLogoBanner();
				 obeGobiernoLogoBanner =  odaGobiernoLogoBanner.traerGobiernoLogoBanner_x_IdLogoBanner(con, IdLogoBanner);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeGobiernoLogoBanner;
			}
	}

	public List<beGobiernoLogoBanner> listarTodos_GobiernoLogoBanner()
	 {
		List<beGobiernoLogoBanner> lbeGobiernoLogoBanner =new List<beGobiernoLogoBanner>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daGobiernoLogoBanner odaGobiernoLogoBanner= new daGobiernoLogoBanner();
				 lbeGobiernoLogoBanner =  odaGobiernoLogoBanner.listarTodos_GobiernoLogoBanner(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeGobiernoLogoBanner;
		}
	}
	public List<beGobiernoLogoBanner> listarTodos_GobiernoLogoBanner_GetAll()
	 {
		List<beGobiernoLogoBanner> lbeGobiernoLogoBanner =new List<beGobiernoLogoBanner>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daGobiernoLogoBanner odaGobiernoLogoBanner= new daGobiernoLogoBanner();
				 lbeGobiernoLogoBanner =  odaGobiernoLogoBanner.listar_GobiernoLogoBanner_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeGobiernoLogoBanner;
		}
	}
}
}

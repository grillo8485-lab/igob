using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiempos:brConexion
		 {
	public int guardarTiempos(beTiempos obeTiempos)
	{
		int IdTiempo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiempos odaTiempos= new daTiempos();
			IdTiempo =  odaTiempos.guardarTiempos(con, obeTiempos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTiempo;
			}
	}

	public int actualizarTiempos(beTiempos obeTiempos)
	{
		int IdTiempo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiempos odaTiempos= new daTiempos();
				IdTiempo =  odaTiempos.actualizarTiempos(con, obeTiempos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTiempo;
			}
	}

	public int eliminarTiempos(int IdTiempo)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiempos odaTiempos= new daTiempos();
				IdTiempo =  odaTiempos.eliminarTiempos(con, IdTiempo);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTiempo;
			}
	}

	public beTiempos traerTiempos_x_IdTiempo (int IdTiempo)
	{
		beTiempos obeTiempos=new beTiempos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiempos odaTiempos= new daTiempos();
				 obeTiempos =  odaTiempos.traerTiempos_x_IdTiempo(con, IdTiempo);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiempos;
			}
	}

	public List<beTiempos> listarTodos_Tiempos()
	 {
		List<beTiempos> lbeTiempos =new List<beTiempos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiempos odaTiempos= new daTiempos();
				 lbeTiempos =  odaTiempos.listarTodos_Tiempos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiempos;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposLugar:brConexion
		 {
	public int guardarTiposLugar(beTiposLugar obeTiposLugar)
	{
		int IdTipoLugar;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposLugar odaTiposLugar= new daTiposLugar();
			IdTipoLugar =  odaTiposLugar.guardarTiposLugar(con, obeTiposLugar);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLugar;
			}
	}

	public int actualizarTiposLugar(beTiposLugar obeTiposLugar)
	{
		int IdTipoLugar;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugar odaTiposLugar= new daTiposLugar();
				IdTipoLugar =  odaTiposLugar.actualizarTiposLugar(con, obeTiposLugar);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLugar;
			}
	}

	public int eliminarTiposLugar(int IdTipoLugar)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugar odaTiposLugar= new daTiposLugar();
				IdTipoLugar =  odaTiposLugar.eliminarTiposLugar(con, IdTipoLugar);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLugar;
			}
	}

	public beTiposLugar traerTiposLugar_x_IdTipoLugar (int IdTipoLugar)
	{
		beTiposLugar obeTiposLugar=new beTiposLugar();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugar odaTiposLugar= new daTiposLugar();
				 obeTiposLugar =  odaTiposLugar.traerTiposLugar_x_IdTipoLugar(con, IdTipoLugar);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposLugar;
			}
	}

	public List<beTiposLugar> listarTodos_TiposLugar()
	 {
		List<beTiposLugar> lbeTiposLugar =new List<beTiposLugar>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugar odaTiposLugar= new daTiposLugar();
				 lbeTiposLugar =  odaTiposLugar.listarTodos_TiposLugar(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLugar;
		}
	}
}
}

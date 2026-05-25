using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposMonedas:brConexion
		 {
	public int guardarTiposMonedas(beTiposMonedas obeTiposMonedas)
	{
		int IdTipoMoneda;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposMonedas odaTiposMonedas= new daTiposMonedas();
			IdTipoMoneda =  odaTiposMonedas.guardarTiposMonedas(con, obeTiposMonedas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoMoneda;
			}
	}

	public int actualizarTiposMonedas(beTiposMonedas obeTiposMonedas)
	{
		int IdTipoMoneda;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposMonedas odaTiposMonedas= new daTiposMonedas();
				IdTipoMoneda =  odaTiposMonedas.actualizarTiposMonedas(con, obeTiposMonedas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoMoneda;
			}
	}

	public int eliminarTiposMonedas(int IdTipoMoneda)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposMonedas odaTiposMonedas= new daTiposMonedas();
				IdTipoMoneda =  odaTiposMonedas.eliminarTiposMonedas(con, IdTipoMoneda);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoMoneda;
			}
	}

	public beTiposMonedas traerTiposMonedas_x_IdTipoMoneda (int IdTipoMoneda)
	{
		beTiposMonedas obeTiposMonedas=new beTiposMonedas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposMonedas odaTiposMonedas= new daTiposMonedas();
				 obeTiposMonedas =  odaTiposMonedas.traerTiposMonedas_x_IdTipoMoneda(con, IdTipoMoneda);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposMonedas;
			}
	}

	public List<beTiposMonedas> listarTodos_TiposMonedas()
	 {
		List<beTiposMonedas> lbeTiposMonedas =new List<beTiposMonedas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposMonedas odaTiposMonedas= new daTiposMonedas();
				 lbeTiposMonedas =  odaTiposMonedas.listarTodos_TiposMonedas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposMonedas;
		}
	}
}
}

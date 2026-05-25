using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brBancos:brConexion
		 {
	public int guardarBancos(beBancos obeBancos)
	{
		int IdBanco;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daBancos odaBancos= new daBancos();
			IdBanco =  odaBancos.guardarBancos(con, obeBancos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdBanco;
			}
	}

	public int actualizarBancos(beBancos obeBancos)
	{
		int IdBanco;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBancos odaBancos= new daBancos();
				IdBanco =  odaBancos.actualizarBancos(con, obeBancos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdBanco;
			}
	}

	public int eliminarBancos(int IdBanco)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBancos odaBancos= new daBancos();
				IdBanco =  odaBancos.eliminarBancos(con, IdBanco);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdBanco;
			}
	}

	public beBancos traerBancos_x_IdBanco (int IdBanco)
	{
		beBancos obeBancos=new beBancos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBancos odaBancos= new daBancos();
				 obeBancos =  odaBancos.traerBancos_x_IdBanco(con, IdBanco);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeBancos;
			}
	}

	public List<beBancos> listarTodos_Bancos()
	 {
		List<beBancos> lbeBancos =new List<beBancos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBancos odaBancos= new daBancos();
				 lbeBancos =  odaBancos.listarTodos_Bancos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeBancos;
		}
	}
}
}

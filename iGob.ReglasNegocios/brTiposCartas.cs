using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposCartas:brConexion
		 {
	public int guardarTiposCartas(beTiposCartas obeTiposCartas)
	{
		int IdTipoCarta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposCartas odaTiposCartas= new daTiposCartas();
			IdTipoCarta =  odaTiposCartas.guardarTiposCartas(con, obeTiposCartas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCarta;
			}
	}

	public int actualizarTiposCartas(beTiposCartas obeTiposCartas)
	{
		int IdTipoCarta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCartas odaTiposCartas= new daTiposCartas();
				IdTipoCarta =  odaTiposCartas.actualizarTiposCartas(con, obeTiposCartas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCarta;
			}
	}

	public int eliminarTiposCartas(int IdTipoCarta)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCartas odaTiposCartas= new daTiposCartas();
				IdTipoCarta =  odaTiposCartas.eliminarTiposCartas(con, IdTipoCarta);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCarta;
			}
	}

	public beTiposCartas traerTiposCartas_x_IdTipoCarta (int IdTipoCarta)
	{
		beTiposCartas obeTiposCartas=new beTiposCartas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCartas odaTiposCartas= new daTiposCartas();
				 obeTiposCartas =  odaTiposCartas.traerTiposCartas_x_IdTipoCarta(con, IdTipoCarta);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposCartas;
			}
	}

	public List<beTiposCartas> listarTodos_TiposCartas()
	 {
		List<beTiposCartas> lbeTiposCartas =new List<beTiposCartas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCartas odaTiposCartas= new daTiposCartas();
				 lbeTiposCartas =  odaTiposCartas.listarTodos_TiposCartas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposCartas;
		}
	}
}
}

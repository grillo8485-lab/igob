using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brCapitulos:brConexion
		 {
	public int guardarCapitulos(beCapitulos obeCapitulos)
	{
		int IdCapitulo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daCapitulos odaCapitulos= new daCapitulos();
			IdCapitulo =  odaCapitulos.guardarCapitulos(con, obeCapitulos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdCapitulo;
			}
	}

	public int actualizarCapitulos(beCapitulos obeCapitulos)
	{
		int IdCapitulo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCapitulos odaCapitulos= new daCapitulos();
				IdCapitulo =  odaCapitulos.actualizarCapitulos(con, obeCapitulos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCapitulo;
			}
	}

	public int eliminarCapitulos(int IdCapitulo)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCapitulos odaCapitulos= new daCapitulos();
				IdCapitulo =  odaCapitulos.eliminarCapitulos(con, IdCapitulo);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCapitulo;
			}
	}

	public beCapitulos traerCapitulos_x_IdCapitulo (int IdCapitulo)
	{
		beCapitulos obeCapitulos=new beCapitulos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCapitulos odaCapitulos= new daCapitulos();
				 obeCapitulos =  odaCapitulos.traerCapitulos_x_IdCapitulo(con, IdCapitulo);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeCapitulos;
			}
	}

	public List<beCapitulos> listarTodos_Capitulos()
	 {
		List<beCapitulos> lbeCapitulos =new List<beCapitulos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCapitulos odaCapitulos= new daCapitulos();
				 lbeCapitulos =  odaCapitulos.listarTodos_Capitulos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeCapitulos;
		}
	}
}
}

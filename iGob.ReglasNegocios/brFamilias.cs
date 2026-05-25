using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brFamilias:brConexion
		 {
	public int guardarFamilias(beFamilias obeFamilias)
	{
		int IdFamilia;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daFamilias odaFamilias= new daFamilias();
			IdFamilia =  odaFamilias.guardarFamilias(con, obeFamilias);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdFamilia;
			}
	}

	public int actualizarFamilias(beFamilias obeFamilias)
	{
		int IdFamilia;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFamilias odaFamilias= new daFamilias();
				IdFamilia =  odaFamilias.actualizarFamilias(con, obeFamilias);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFamilia;
			}
	}

	public int eliminarFamilias(int IdFamilia)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFamilias odaFamilias= new daFamilias();
				IdFamilia =  odaFamilias.eliminarFamilias(con, IdFamilia);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFamilia;
			}
	}

	public beFamilias traerFamilias_x_IdFamilia (int IdFamilia)
	{
		beFamilias obeFamilias=new beFamilias();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFamilias odaFamilias= new daFamilias();
				 obeFamilias =  odaFamilias.traerFamilias_x_IdFamilia(con, IdFamilia);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeFamilias;
			}
	}

	public List<beFamilias> listarTodos_Familias()
	 {
		List<beFamilias> lbeFamilias =new List<beFamilias>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFamilias odaFamilias= new daFamilias();
				 lbeFamilias =  odaFamilias.listarTodos_Familias(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeFamilias;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brFrecuencias:brConexion
		 {
	public int guardarFrecuencias(beFrecuencias obeFrecuencias)
	{
		int IdFrecuencia;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daFrecuencias odaFrecuencias= new daFrecuencias();
			IdFrecuencia =  odaFrecuencias.guardarFrecuencias(con, obeFrecuencias);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdFrecuencia;
			}
	}

	public int actualizarFrecuencias(beFrecuencias obeFrecuencias)
	{
		int IdFrecuencia;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFrecuencias odaFrecuencias= new daFrecuencias();
				IdFrecuencia =  odaFrecuencias.actualizarFrecuencias(con, obeFrecuencias);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFrecuencia;
			}
	}

	public int eliminarFrecuencias(int IdFrecuencia)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFrecuencias odaFrecuencias= new daFrecuencias();
				IdFrecuencia =  odaFrecuencias.eliminarFrecuencias(con, IdFrecuencia);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFrecuencia;
			}
	}

	public beFrecuencias traerFrecuencias_x_IdFrecuencia (int IdFrecuencia)
	{
		beFrecuencias obeFrecuencias=new beFrecuencias();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFrecuencias odaFrecuencias= new daFrecuencias();
				 obeFrecuencias =  odaFrecuencias.traerFrecuencias_x_IdFrecuencia(con, IdFrecuencia);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeFrecuencias;
			}
	}

	public List<beFrecuencias> listarTodos_Frecuencias()
	 {
		List<beFrecuencias> lbeFrecuencias =new List<beFrecuencias>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFrecuencias odaFrecuencias= new daFrecuencias();
				 lbeFrecuencias =  odaFrecuencias.listarTodos_Frecuencias(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeFrecuencias;
		}
	}
}
}

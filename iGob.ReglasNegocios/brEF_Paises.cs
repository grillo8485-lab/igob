using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brEF_Paises:brConexion
		 {
	public int guardarEF_Paises(beEF_Paises obeEF_Paises)
	{
		int IdPais;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daEF_Paises odaEF_Paises= new daEF_Paises();
			IdPais =  odaEF_Paises.guardarEF_Paises(con, obeEF_Paises);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPais;
			}
	}

	public int actualizarEF_Paises(beEF_Paises obeEF_Paises)
	{
		int IdPais;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Paises odaEF_Paises= new daEF_Paises();
				IdPais =  odaEF_Paises.actualizarEF_Paises(con, obeEF_Paises);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPais;
			}
	}

	public int eliminarEF_Paises(int IdPais)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Paises odaEF_Paises= new daEF_Paises();
				IdPais =  odaEF_Paises.eliminarEF_Paises(con, IdPais);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPais;
			}
	}

	public beEF_Paises traerEF_Paises_x_IdPais (int IdPais)
	{
		beEF_Paises obeEF_Paises=new beEF_Paises();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Paises odaEF_Paises= new daEF_Paises();
				 obeEF_Paises =  odaEF_Paises.traerEF_Paises_x_IdPais(con, IdPais);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEF_Paises;
			}
	}

	public List<beEF_Paises> listarTodos_EF_Paises()
	 {
		List<beEF_Paises> lbeEF_Paises =new List<beEF_Paises>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Paises odaEF_Paises= new daEF_Paises();
				 lbeEF_Paises =  odaEF_Paises.listarTodos_EF_Paises(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_Paises;
		}
	}
	public List<beEF_Paises> listarTodos_EF_Paises_GetAll()
	 {
		List<beEF_Paises> lbeEF_Paises =new List<beEF_Paises>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Paises odaEF_Paises= new daEF_Paises();
				 lbeEF_Paises =  odaEF_Paises.listar_EF_Paises_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_Paises;
		}
	}
}
}

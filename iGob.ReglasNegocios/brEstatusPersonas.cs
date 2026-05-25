using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brEstatusPersonas:brConexion
		 {
	public int guardarEstatusPersonas(beEstatusPersonas obeEstatusPersonas)
	{
		int IdEstatusPersona;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daEstatusPersonas odaEstatusPersonas= new daEstatusPersonas();
			IdEstatusPersona =  odaEstatusPersonas.guardarEstatusPersonas(con, obeEstatusPersonas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPersona;
			}
	}

	public int actualizarEstatusPersonas(beEstatusPersonas obeEstatusPersonas)
	{
		int IdEstatusPersona;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPersonas odaEstatusPersonas= new daEstatusPersonas();
				IdEstatusPersona =  odaEstatusPersonas.actualizarEstatusPersonas(con, obeEstatusPersonas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPersona;
			}
	}

	public int eliminarEstatusPersonas(int IdEstatusPersona)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPersonas odaEstatusPersonas= new daEstatusPersonas();
				IdEstatusPersona =  odaEstatusPersonas.eliminarEstatusPersonas(con, IdEstatusPersona);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPersona;
			}
	}

	public beEstatusPersonas traerEstatusPersonas_x_IdEstatusPersona (int IdEstatusPersona)
	{
		beEstatusPersonas obeEstatusPersonas=new beEstatusPersonas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPersonas odaEstatusPersonas= new daEstatusPersonas();
				 obeEstatusPersonas =  odaEstatusPersonas.traerEstatusPersonas_x_IdEstatusPersona(con, IdEstatusPersona);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusPersonas;
			}
	}

	public List<beEstatusPersonas> listarTodos_EstatusPersonas()
	 {
		List<beEstatusPersonas> lbeEstatusPersonas =new List<beEstatusPersonas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPersonas odaEstatusPersonas= new daEstatusPersonas();
				 lbeEstatusPersonas =  odaEstatusPersonas.listarTodos_EstatusPersonas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPersonas;
		}
	}
	public List<beEstatusPersonas> listarTodos_EstatusPersonas_GetAll()
	 {
		List<beEstatusPersonas> lbeEstatusPersonas =new List<beEstatusPersonas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPersonas odaEstatusPersonas= new daEstatusPersonas();
				 lbeEstatusPersonas =  odaEstatusPersonas.listar_EstatusPersonas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPersonas;
		}
	}
}
}

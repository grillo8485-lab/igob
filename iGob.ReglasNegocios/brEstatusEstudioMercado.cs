using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brEstatusEstudioMercado:brConexion
		 {
	public int guardarEstatusEstudioMercado(beEstatusEstudioMercado obeEstatusEstudioMercado)
	{
		int IdEstatusEstudioMercado;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daEstatusEstudioMercado odaEstatusEstudioMercado= new daEstatusEstudioMercado();
			IdEstatusEstudioMercado =  odaEstatusEstudioMercado.guardarEstatusEstudioMercado(con, obeEstatusEstudioMercado);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusEstudioMercado;
			}
	}

	public int actualizarEstatusEstudioMercado(beEstatusEstudioMercado obeEstatusEstudioMercado)
	{
		int IdEstatusEstudioMercado;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusEstudioMercado odaEstatusEstudioMercado= new daEstatusEstudioMercado();
				IdEstatusEstudioMercado =  odaEstatusEstudioMercado.actualizarEstatusEstudioMercado(con, obeEstatusEstudioMercado);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusEstudioMercado;
			}
	}

	public int eliminarEstatusEstudioMercado(int IdEstatusEstudioMercado)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusEstudioMercado odaEstatusEstudioMercado= new daEstatusEstudioMercado();
				IdEstatusEstudioMercado =  odaEstatusEstudioMercado.eliminarEstatusEstudioMercado(con, IdEstatusEstudioMercado);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusEstudioMercado;
			}
	}

	public beEstatusEstudioMercado traerEstatusEstudioMercado_x_IdEstatusEstudioMercado (int IdEstatusEstudioMercado)
	{
		beEstatusEstudioMercado obeEstatusEstudioMercado=new beEstatusEstudioMercado();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusEstudioMercado odaEstatusEstudioMercado= new daEstatusEstudioMercado();
				 obeEstatusEstudioMercado =  odaEstatusEstudioMercado.traerEstatusEstudioMercado_x_IdEstatusEstudioMercado(con, IdEstatusEstudioMercado);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusEstudioMercado;
			}
	}

	public List<beEstatusEstudioMercado> listarTodos_EstatusEstudioMercado()
	 {
		List<beEstatusEstudioMercado> lbeEstatusEstudioMercado =new List<beEstatusEstudioMercado>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusEstudioMercado odaEstatusEstudioMercado= new daEstatusEstudioMercado();
				 lbeEstatusEstudioMercado =  odaEstatusEstudioMercado.listarTodos_EstatusEstudioMercado(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusEstudioMercado;
		}
	}
	public List<beEstatusEstudioMercado> listarTodos_EstatusEstudioMercado_GetAll()
	 {
		List<beEstatusEstudioMercado> lbeEstatusEstudioMercado =new List<beEstatusEstudioMercado>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusEstudioMercado odaEstatusEstudioMercado= new daEstatusEstudioMercado();
				 lbeEstatusEstudioMercado =  odaEstatusEstudioMercado.listar_EstatusEstudioMercado_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusEstudioMercado;
		}
	}
}
}

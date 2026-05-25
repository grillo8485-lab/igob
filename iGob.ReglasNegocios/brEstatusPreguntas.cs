using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brEstatusPreguntas:brConexion
		 {
	public int guardarEstatusPreguntas(beEstatusPreguntas obeEstatusPreguntas)
	{
		int IdEstatusPregunta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daEstatusPreguntas odaEstatusPreguntas= new daEstatusPreguntas();
			IdEstatusPregunta =  odaEstatusPreguntas.guardarEstatusPreguntas(con, obeEstatusPreguntas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPregunta;
			}
	}

	public int actualizarEstatusPreguntas(beEstatusPreguntas obeEstatusPreguntas)
	{
		int IdEstatusPregunta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPreguntas odaEstatusPreguntas= new daEstatusPreguntas();
				IdEstatusPregunta =  odaEstatusPreguntas.actualizarEstatusPreguntas(con, obeEstatusPreguntas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPregunta;
			}
	}

	public int eliminarEstatusPreguntas(int IdEstatusPregunta)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPreguntas odaEstatusPreguntas= new daEstatusPreguntas();
				IdEstatusPregunta =  odaEstatusPreguntas.eliminarEstatusPreguntas(con, IdEstatusPregunta);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPregunta;
			}
	}

	public beEstatusPreguntas traerEstatusPreguntas_x_IdEstatusPregunta (int IdEstatusPregunta)
	{
		beEstatusPreguntas obeEstatusPreguntas=new beEstatusPreguntas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPreguntas odaEstatusPreguntas= new daEstatusPreguntas();
				 obeEstatusPreguntas =  odaEstatusPreguntas.traerEstatusPreguntas_x_IdEstatusPregunta(con, IdEstatusPregunta);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusPreguntas;
			}
	}

	public List<beEstatusPreguntas> listarTodos_EstatusPreguntas()
	 {
		List<beEstatusPreguntas> lbeEstatusPreguntas =new List<beEstatusPreguntas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPreguntas odaEstatusPreguntas= new daEstatusPreguntas();
				 lbeEstatusPreguntas =  odaEstatusPreguntas.listarTodos_EstatusPreguntas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPreguntas;
		}
	}
	public List<beEstatusPreguntas> listarTodos_EstatusPreguntas_GetAll()
	 {
		List<beEstatusPreguntas> lbeEstatusPreguntas =new List<beEstatusPreguntas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPreguntas odaEstatusPreguntas= new daEstatusPreguntas();
				 lbeEstatusPreguntas =  odaEstatusPreguntas.listar_EstatusPreguntas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPreguntas;
		}
	}
}
}

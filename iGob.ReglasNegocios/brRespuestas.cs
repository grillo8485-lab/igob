using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRespuestas:brConexion
		 {
	public int guardarRespuestas(beRespuestas obeRespuestas)
	{
		int IdRespuesta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRespuestas odaRespuestas= new daRespuestas();
			IdRespuesta =  odaRespuestas.guardarRespuestas(con, obeRespuestas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRespuesta;
			}
	}

	public int actualizarRespuestas(beRespuestas obeRespuestas)
	{
		int IdRespuesta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestas odaRespuestas= new daRespuestas();
				IdRespuesta =  odaRespuestas.actualizarRespuestas(con, obeRespuestas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRespuesta;
			}
	}

	public int eliminarRespuestas(int IdRespuesta)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestas odaRespuestas= new daRespuestas();
				IdRespuesta =  odaRespuestas.eliminarRespuestas(con, IdRespuesta);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRespuesta;
			}
	}

	public beRespuestas traerRespuestas_x_IdRespuesta (int IdRespuesta)
	{
		beRespuestas obeRespuestas=new beRespuestas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestas odaRespuestas= new daRespuestas();
				 obeRespuestas =  odaRespuestas.traerRespuestas_x_IdRespuesta(con, IdRespuesta);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRespuestas;
			}
	}

	public List<beRespuestas> listarTodos_Respuestas()
	 {
		List<beRespuestas> lbeRespuestas =new List<beRespuestas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestas odaRespuestas= new daRespuestas();
				 lbeRespuestas =  odaRespuestas.listarTodos_Respuestas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRespuestas;
		}
	}
	public List<beRespuestas> listarTodos_Respuestas_GetAll()
	 {
		List<beRespuestas> lbeRespuestas =new List<beRespuestas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestas odaRespuestas= new daRespuestas();
				 lbeRespuestas =  odaRespuestas.listar_Respuestas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRespuestas;
		}
	}
}
}

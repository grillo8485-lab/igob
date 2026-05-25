using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRespuestasRechazadas:brConexion
		 {
	public int guardarRespuestasRechazadas(beRespuestasRechazadas obeRespuestasRechazadas)
	{
		int IdRespuestaRechazada;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRespuestasRechazadas odaRespuestasRechazadas= new daRespuestasRechazadas();
			IdRespuestaRechazada =  odaRespuestasRechazadas.guardarRespuestasRechazadas(con, obeRespuestasRechazadas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRespuestaRechazada;
			}
	}

	public int actualizarRespuestasRechazadas(beRespuestasRechazadas obeRespuestasRechazadas)
	{
		int IdRespuestaRechazada;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestasRechazadas odaRespuestasRechazadas= new daRespuestasRechazadas();
				IdRespuestaRechazada =  odaRespuestasRechazadas.actualizarRespuestasRechazadas(con, obeRespuestasRechazadas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRespuestaRechazada;
			}
	}

	public int eliminarRespuestasRechazadas(int IdRespuestaRechazada)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestasRechazadas odaRespuestasRechazadas= new daRespuestasRechazadas();
				IdRespuestaRechazada =  odaRespuestasRechazadas.eliminarRespuestasRechazadas(con, IdRespuestaRechazada);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRespuestaRechazada;
			}
	}

	public beRespuestasRechazadas traerRespuestasRechazadas_x_IdRespuestaRechazada (int IdRespuestaRechazada)
	{
		beRespuestasRechazadas obeRespuestasRechazadas=new beRespuestasRechazadas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestasRechazadas odaRespuestasRechazadas= new daRespuestasRechazadas();
				 obeRespuestasRechazadas =  odaRespuestasRechazadas.traerRespuestasRechazadas_x_IdRespuestaRechazada(con, IdRespuestaRechazada);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRespuestasRechazadas;
			}
	}

	public List<beRespuestasRechazadas> listarTodos_RespuestasRechazadas()
	 {
		List<beRespuestasRechazadas> lbeRespuestasRechazadas =new List<beRespuestasRechazadas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestasRechazadas odaRespuestasRechazadas= new daRespuestasRechazadas();
				 lbeRespuestasRechazadas =  odaRespuestasRechazadas.listarTodos_RespuestasRechazadas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRespuestasRechazadas;
		}
	}
	public List<beRespuestasRechazadas> listarTodos_RespuestasRechazadas_GetAll()
	 {
		List<beRespuestasRechazadas> lbeRespuestasRechazadas =new List<beRespuestasRechazadas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRespuestasRechazadas odaRespuestasRechazadas= new daRespuestasRechazadas();
				 lbeRespuestasRechazadas =  odaRespuestasRechazadas.listar_RespuestasRechazadas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRespuestasRechazadas;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brProveedoresPreguntas:brConexion
		 {
	public int guardarProveedoresPreguntas(beProveedoresPreguntas obeProveedoresPreguntas)
	{
		int IdPregunta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daProveedoresPreguntas odaProveedoresPreguntas= new daProveedoresPreguntas();
			IdPregunta =  odaProveedoresPreguntas.guardarProveedoresPreguntas(con, obeProveedoresPreguntas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPregunta;
			}
	}

	public int actualizarProveedoresPreguntas(beProveedoresPreguntas obeProveedoresPreguntas)
	{
		int IdPregunta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresPreguntas odaProveedoresPreguntas= new daProveedoresPreguntas();
				IdPregunta =  odaProveedoresPreguntas.actualizarProveedoresPreguntas(con, obeProveedoresPreguntas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPregunta;
			}
	}

	public int eliminarProveedoresPreguntas(int IdPregunta)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresPreguntas odaProveedoresPreguntas= new daProveedoresPreguntas();
				IdPregunta =  odaProveedoresPreguntas.eliminarProveedoresPreguntas(con, IdPregunta);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPregunta;
			}
	}

	public beProveedoresPreguntas traerProveedoresPreguntas_x_IdPregunta (int IdPregunta)
	{
		beProveedoresPreguntas obeProveedoresPreguntas=new beProveedoresPreguntas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresPreguntas odaProveedoresPreguntas= new daProveedoresPreguntas();
				 obeProveedoresPreguntas =  odaProveedoresPreguntas.traerProveedoresPreguntas_x_IdPregunta(con, IdPregunta);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresPreguntas;
			}
	}

	public List<beProveedoresPreguntas> listarTodos_ProveedoresPreguntas()
	 {
		List<beProveedoresPreguntas> lbeProveedoresPreguntas =new List<beProveedoresPreguntas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresPreguntas odaProveedoresPreguntas= new daProveedoresPreguntas();
				 lbeProveedoresPreguntas =  odaProveedoresPreguntas.listarTodos_ProveedoresPreguntas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresPreguntas;
		}
	}
	public List<beProveedoresPreguntas> listarTodos_ProveedoresPreguntas_GetAll()
	 {
		List<beProveedoresPreguntas> lbeProveedoresPreguntas =new List<beProveedoresPreguntas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresPreguntas odaProveedoresPreguntas= new daProveedoresPreguntas();
				 lbeProveedoresPreguntas =  odaProveedoresPreguntas.listar_ProveedoresPreguntas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresPreguntas;
		}
	}
}
}

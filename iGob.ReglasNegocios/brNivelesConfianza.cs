using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brNivelesConfianza:brConexion
		 {
	public int guardarNivelesConfianza(beNivelesConfianza obeNivelesConfianza)
	{
		int IdNivelConfianza;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daNivelesConfianza odaNivelesConfianza= new daNivelesConfianza();
			IdNivelConfianza =  odaNivelesConfianza.guardarNivelesConfianza(con, obeNivelesConfianza);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdNivelConfianza;
			}
	}

	public int actualizarNivelesConfianza(beNivelesConfianza obeNivelesConfianza)
	{
		int IdNivelConfianza;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daNivelesConfianza odaNivelesConfianza= new daNivelesConfianza();
				IdNivelConfianza =  odaNivelesConfianza.actualizarNivelesConfianza(con, obeNivelesConfianza);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdNivelConfianza;
			}
	}

	public int eliminarNivelesConfianza(int IdNivelConfianza)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daNivelesConfianza odaNivelesConfianza= new daNivelesConfianza();
				IdNivelConfianza =  odaNivelesConfianza.eliminarNivelesConfianza(con, IdNivelConfianza);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdNivelConfianza;
			}
	}

	public beNivelesConfianza traerNivelesConfianza_x_IdNivelConfianza (int IdNivelConfianza)
	{
		beNivelesConfianza obeNivelesConfianza=new beNivelesConfianza();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daNivelesConfianza odaNivelesConfianza= new daNivelesConfianza();
				 obeNivelesConfianza =  odaNivelesConfianza.traerNivelesConfianza_x_IdNivelConfianza(con, IdNivelConfianza);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeNivelesConfianza;
			}
	}

	public List<beNivelesConfianza> listarTodos_NivelesConfianza()
	 {
		List<beNivelesConfianza> lbeNivelesConfianza =new List<beNivelesConfianza>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daNivelesConfianza odaNivelesConfianza= new daNivelesConfianza();
				 lbeNivelesConfianza =  odaNivelesConfianza.listarTodos_NivelesConfianza(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeNivelesConfianza;
		}
	}
	public List<beNivelesConfianza> listarTodos_NivelesConfianza_GetAll()
	 {
		List<beNivelesConfianza> lbeNivelesConfianza =new List<beNivelesConfianza>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daNivelesConfianza odaNivelesConfianza= new daNivelesConfianza();
				 lbeNivelesConfianza =  odaNivelesConfianza.listar_NivelesConfianza_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeNivelesConfianza;
		}
	}
}
}

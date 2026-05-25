using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brAdjudicaciones:brConexion
		 {
	public int guardarAdjudicaciones(beAdjudicaciones obeAdjudicaciones)
	{
		int IdAdjudicacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicaciones odaAdjudicaciones= new daAdjudicaciones();
			IdAdjudicacion =  odaAdjudicaciones.guardarAdjudicaciones(con, obeAdjudicaciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacion;
			}
	}

	public int actualizarAdjudicaciones(beAdjudicaciones obeAdjudicaciones)
	{
		int IdAdjudicacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicaciones odaAdjudicaciones= new daAdjudicaciones();
				IdAdjudicacion =  odaAdjudicaciones.actualizarAdjudicaciones(con, obeAdjudicaciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacion;
			}
	}

	public int eliminarAdjudicaciones(int IdAdjudicacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicaciones odaAdjudicaciones= new daAdjudicaciones();
				IdAdjudicacion =  odaAdjudicaciones.eliminarAdjudicaciones(con, IdAdjudicacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacion;
			}
	}

	public beAdjudicaciones traerAdjudicaciones_x_IdAdjudicacion (int IdAdjudicacion)
	{
		beAdjudicaciones obeAdjudicaciones=new beAdjudicaciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicaciones odaAdjudicaciones= new daAdjudicaciones();
				 obeAdjudicaciones =  odaAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(con, IdAdjudicacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicaciones;
			}
	}

	public List<beAdjudicaciones> listarTodos_Adjudicaciones()
	 {
		List<beAdjudicaciones> lbeAdjudicaciones =new List<beAdjudicaciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicaciones odaAdjudicaciones= new daAdjudicaciones();
				 lbeAdjudicaciones =  odaAdjudicaciones.listarTodos_Adjudicaciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicaciones;
		}
	}
	public List<beAdjudicaciones> listarTodos_Adjudicaciones_GetAll()
	 {
		List<beAdjudicaciones> lbeAdjudicaciones =new List<beAdjudicaciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicaciones odaAdjudicaciones= new daAdjudicaciones();
				 lbeAdjudicaciones =  odaAdjudicaciones.listar_Adjudicaciones_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicaciones;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesSeguimiento:brConexion
		 {
	public int guardarAdjudicacionesSeguimiento(beAdjudicacionesSeguimiento obeAdjudicacionesSeguimiento)
	{
		int IdAdjudicacionSeguimiento;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesSeguimiento odaAdjudicacionesSeguimiento= new daAdjudicacionesSeguimiento();
			IdAdjudicacionSeguimiento =  odaAdjudicacionesSeguimiento.guardarAdjudicacionesSeguimiento(con, obeAdjudicacionesSeguimiento);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionSeguimiento;
			}
	}

	public int actualizarAdjudicacionesSeguimiento(beAdjudicacionesSeguimiento obeAdjudicacionesSeguimiento)
	{
		int IdAdjudicacionSeguimiento;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesSeguimiento odaAdjudicacionesSeguimiento= new daAdjudicacionesSeguimiento();
				IdAdjudicacionSeguimiento =  odaAdjudicacionesSeguimiento.actualizarAdjudicacionesSeguimiento(con, obeAdjudicacionesSeguimiento);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionSeguimiento;
			}
	}

	public int eliminarAdjudicacionesSeguimiento(int IdAdjudicacionSeguimiento)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesSeguimiento odaAdjudicacionesSeguimiento= new daAdjudicacionesSeguimiento();
				IdAdjudicacionSeguimiento =  odaAdjudicacionesSeguimiento.eliminarAdjudicacionesSeguimiento(con, IdAdjudicacionSeguimiento);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionSeguimiento;
			}
	}

	public beAdjudicacionesSeguimiento traerAdjudicacionesSeguimiento_x_IdAdjudicacionSeguimiento (int IdAdjudicacionSeguimiento)
	{
		beAdjudicacionesSeguimiento obeAdjudicacionesSeguimiento=new beAdjudicacionesSeguimiento();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesSeguimiento odaAdjudicacionesSeguimiento= new daAdjudicacionesSeguimiento();
				 obeAdjudicacionesSeguimiento =  odaAdjudicacionesSeguimiento.traerAdjudicacionesSeguimiento_x_IdAdjudicacionSeguimiento(con, IdAdjudicacionSeguimiento);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesSeguimiento;
			}
	}

	public List<beAdjudicacionesSeguimiento> listarTodos_AdjudicacionesSeguimiento()
	 {
		List<beAdjudicacionesSeguimiento> lbeAdjudicacionesSeguimiento =new List<beAdjudicacionesSeguimiento>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesSeguimiento odaAdjudicacionesSeguimiento= new daAdjudicacionesSeguimiento();
				 lbeAdjudicacionesSeguimiento =  odaAdjudicacionesSeguimiento.listarTodos_AdjudicacionesSeguimiento(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesSeguimiento;
		}
	}
	public List<beAdjudicacionesSeguimiento> listarTodos_AdjudicacionesSeguimiento_GetAll()
	 {
		List<beAdjudicacionesSeguimiento> lbeAdjudicacionesSeguimiento =new List<beAdjudicacionesSeguimiento>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesSeguimiento odaAdjudicacionesSeguimiento= new daAdjudicacionesSeguimiento();
				 lbeAdjudicacionesSeguimiento =  odaAdjudicacionesSeguimiento.listar_AdjudicacionesSeguimiento_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesSeguimiento;
		}
	}
}
}

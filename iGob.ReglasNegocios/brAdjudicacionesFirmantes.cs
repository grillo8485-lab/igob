using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesFirmantes:brConexion
		 {
	public int guardarAdjudicacionesFirmantes(beAdjudicacionesFirmantes obeAdjudicacionesFirmantes)
	{
		int IdAdjudicacionFirmante;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesFirmantes odaAdjudicacionesFirmantes= new daAdjudicacionesFirmantes();
			IdAdjudicacionFirmante =  odaAdjudicacionesFirmantes.guardarAdjudicacionesFirmantes(con, obeAdjudicacionesFirmantes);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionFirmante;
			}
	}

	public int actualizarAdjudicacionesFirmantes(beAdjudicacionesFirmantes obeAdjudicacionesFirmantes)
	{
		int IdAdjudicacionFirmante;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesFirmantes odaAdjudicacionesFirmantes= new daAdjudicacionesFirmantes();
				IdAdjudicacionFirmante =  odaAdjudicacionesFirmantes.actualizarAdjudicacionesFirmantes(con, obeAdjudicacionesFirmantes);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionFirmante;
			}
	}

	public int eliminarAdjudicacionesFirmantes(int IdAdjudicacionFirmante)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesFirmantes odaAdjudicacionesFirmantes= new daAdjudicacionesFirmantes();
				IdAdjudicacionFirmante =  odaAdjudicacionesFirmantes.eliminarAdjudicacionesFirmantes(con, IdAdjudicacionFirmante);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionFirmante;
			}
	}

	public beAdjudicacionesFirmantes traerAdjudicacionesFirmantes_x_IdAdjudicacionFirmante (int IdAdjudicacionFirmante)
	{
		beAdjudicacionesFirmantes obeAdjudicacionesFirmantes=new beAdjudicacionesFirmantes();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesFirmantes odaAdjudicacionesFirmantes= new daAdjudicacionesFirmantes();
				 obeAdjudicacionesFirmantes =  odaAdjudicacionesFirmantes.traerAdjudicacionesFirmantes_x_IdAdjudicacionFirmante(con, IdAdjudicacionFirmante);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesFirmantes;
			}
	}

	public List<beAdjudicacionesFirmantes> listarTodos_AdjudicacionesFirmantes()
	 {
		List<beAdjudicacionesFirmantes> lbeAdjudicacionesFirmantes =new List<beAdjudicacionesFirmantes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesFirmantes odaAdjudicacionesFirmantes= new daAdjudicacionesFirmantes();
				 lbeAdjudicacionesFirmantes =  odaAdjudicacionesFirmantes.listarTodos_AdjudicacionesFirmantes(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesFirmantes;
		}
	}
	public List<beAdjudicacionesFirmantes> listarTodos_AdjudicacionesFirmantes_GetAll()
	 {
		List<beAdjudicacionesFirmantes> lbeAdjudicacionesFirmantes =new List<beAdjudicacionesFirmantes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesFirmantes odaAdjudicacionesFirmantes= new daAdjudicacionesFirmantes();
				 lbeAdjudicacionesFirmantes =  odaAdjudicacionesFirmantes.listar_AdjudicacionesFirmantes_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesFirmantes;
		}
	}
}
}

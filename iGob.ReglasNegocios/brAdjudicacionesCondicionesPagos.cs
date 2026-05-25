using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesCondicionesPagos:brConexion
		 {
	public int guardarAdjudicacionesCondicionesPagos(beAdjudicacionesCondicionesPagos obeAdjudicacionesCondicionesPagos)
	{
		int IdAdjudicacionCondicionPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesCondicionesPagos odaAdjudicacionesCondicionesPagos= new daAdjudicacionesCondicionesPagos();
			IdAdjudicacionCondicionPago =  odaAdjudicacionesCondicionesPagos.guardarAdjudicacionesCondicionesPagos(con, obeAdjudicacionesCondicionesPagos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionCondicionPago;
			}
	}

	public int actualizarAdjudicacionesCondicionesPagos(beAdjudicacionesCondicionesPagos obeAdjudicacionesCondicionesPagos)
	{
		int IdAdjudicacionCondicionPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagos odaAdjudicacionesCondicionesPagos= new daAdjudicacionesCondicionesPagos();
				IdAdjudicacionCondicionPago =  odaAdjudicacionesCondicionesPagos.actualizarAdjudicacionesCondicionesPagos(con, obeAdjudicacionesCondicionesPagos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionCondicionPago;
			}
	}

	public int eliminarAdjudicacionesCondicionesPagos(int IdAdjudicacionCondicionPago)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagos odaAdjudicacionesCondicionesPagos= new daAdjudicacionesCondicionesPagos();
				IdAdjudicacionCondicionPago =  odaAdjudicacionesCondicionesPagos.eliminarAdjudicacionesCondicionesPagos(con, IdAdjudicacionCondicionPago);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionCondicionPago;
			}
	}

	public beAdjudicacionesCondicionesPagos traerAdjudicacionesCondicionesPagos_x_IdAdjudicacionCondicionPago (int IdAdjudicacionCondicionPago)
	{
		beAdjudicacionesCondicionesPagos obeAdjudicacionesCondicionesPagos=new beAdjudicacionesCondicionesPagos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagos odaAdjudicacionesCondicionesPagos= new daAdjudicacionesCondicionesPagos();
				 obeAdjudicacionesCondicionesPagos =  odaAdjudicacionesCondicionesPagos.traerAdjudicacionesCondicionesPagos_x_IdAdjudicacionCondicionPago(con, IdAdjudicacionCondicionPago);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesCondicionesPagos;
			}
	}

	public List<beAdjudicacionesCondicionesPagos> listarTodos_AdjudicacionesCondicionesPagos()
	 {
		List<beAdjudicacionesCondicionesPagos> lbeAdjudicacionesCondicionesPagos =new List<beAdjudicacionesCondicionesPagos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagos odaAdjudicacionesCondicionesPagos= new daAdjudicacionesCondicionesPagos();
				 lbeAdjudicacionesCondicionesPagos =  odaAdjudicacionesCondicionesPagos.listarTodos_AdjudicacionesCondicionesPagos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesPagos;
		}
	}
	public List<beAdjudicacionesCondicionesPagos> listarTodos_AdjudicacionesCondicionesPagos_GetAll()
	 {
		List<beAdjudicacionesCondicionesPagos> lbeAdjudicacionesCondicionesPagos =new List<beAdjudicacionesCondicionesPagos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesPagos odaAdjudicacionesCondicionesPagos= new daAdjudicacionesCondicionesPagos();
				 lbeAdjudicacionesCondicionesPagos =  odaAdjudicacionesCondicionesPagos.listar_AdjudicacionesCondicionesPagos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesPagos;
		}
	}
}
}

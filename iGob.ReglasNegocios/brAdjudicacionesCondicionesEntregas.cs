using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesCondicionesEntregas:brConexion
		 {
	public int guardarAdjudicacionesCondicionesEntregas(beAdjudicacionesCondicionesEntregas obeAdjudicacionesCondicionesEntregas)
	{
		int IdAdjudicacionCondicionEntrega;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesCondicionesEntregas odaAdjudicacionesCondicionesEntregas= new daAdjudicacionesCondicionesEntregas();
			IdAdjudicacionCondicionEntrega =  odaAdjudicacionesCondicionesEntregas.guardarAdjudicacionesCondicionesEntregas(con, obeAdjudicacionesCondicionesEntregas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionCondicionEntrega;
			}
	}

	public int actualizarAdjudicacionesCondicionesEntregas(beAdjudicacionesCondicionesEntregas obeAdjudicacionesCondicionesEntregas)
	{
		int IdAdjudicacionCondicionEntrega;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregas odaAdjudicacionesCondicionesEntregas= new daAdjudicacionesCondicionesEntregas();
				IdAdjudicacionCondicionEntrega =  odaAdjudicacionesCondicionesEntregas.actualizarAdjudicacionesCondicionesEntregas(con, obeAdjudicacionesCondicionesEntregas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionCondicionEntrega;
			}
	}

	public int eliminarAdjudicacionesCondicionesEntregas(int IdAdjudicacionCondicionEntrega)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregas odaAdjudicacionesCondicionesEntregas= new daAdjudicacionesCondicionesEntregas();
				IdAdjudicacionCondicionEntrega =  odaAdjudicacionesCondicionesEntregas.eliminarAdjudicacionesCondicionesEntregas(con, IdAdjudicacionCondicionEntrega);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionCondicionEntrega;
			}
	}

	public beAdjudicacionesCondicionesEntregas traerAdjudicacionesCondicionesEntregas_x_IdAdjudicacionCondicionEntrega (int IdAdjudicacionCondicionEntrega)
	{
		beAdjudicacionesCondicionesEntregas obeAdjudicacionesCondicionesEntregas=new beAdjudicacionesCondicionesEntregas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregas odaAdjudicacionesCondicionesEntregas= new daAdjudicacionesCondicionesEntregas();
				 obeAdjudicacionesCondicionesEntregas =  odaAdjudicacionesCondicionesEntregas.traerAdjudicacionesCondicionesEntregas_x_IdAdjudicacionCondicionEntrega(con, IdAdjudicacionCondicionEntrega);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesCondicionesEntregas;
			}
	}

	public List<beAdjudicacionesCondicionesEntregas> listarTodos_AdjudicacionesCondicionesEntregas()
	 {
		List<beAdjudicacionesCondicionesEntregas> lbeAdjudicacionesCondicionesEntregas =new List<beAdjudicacionesCondicionesEntregas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregas odaAdjudicacionesCondicionesEntregas= new daAdjudicacionesCondicionesEntregas();
				 lbeAdjudicacionesCondicionesEntregas =  odaAdjudicacionesCondicionesEntregas.listarTodos_AdjudicacionesCondicionesEntregas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesEntregas;
		}
	}
	public List<beAdjudicacionesCondicionesEntregas> listarTodos_AdjudicacionesCondicionesEntregas_GetAll()
	 {
		List<beAdjudicacionesCondicionesEntregas> lbeAdjudicacionesCondicionesEntregas =new List<beAdjudicacionesCondicionesEntregas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesCondicionesEntregas odaAdjudicacionesCondicionesEntregas= new daAdjudicacionesCondicionesEntregas();
				 lbeAdjudicacionesCondicionesEntregas =  odaAdjudicacionesCondicionesEntregas.listar_AdjudicacionesCondicionesEntregas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesEntregas;
		}
	}
}
}

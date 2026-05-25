using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesPedidosFirmantes:brConexion
		 {
	public int guardarAdjudicacionesPedidosFirmantes(beAdjudicacionesPedidosFirmantes obeAdjudicacionesPedidosFirmantes)
	{
		int IdAdjudicacionPedidoFirmante;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesPedidosFirmantes odaAdjudicacionesPedidosFirmantes= new daAdjudicacionesPedidosFirmantes();
			IdAdjudicacionPedidoFirmante =  odaAdjudicacionesPedidosFirmantes.guardarAdjudicacionesPedidosFirmantes(con, obeAdjudicacionesPedidosFirmantes);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedidoFirmante;
			}
	}

	public int actualizarAdjudicacionesPedidosFirmantes(beAdjudicacionesPedidosFirmantes obeAdjudicacionesPedidosFirmantes)
	{
		int IdAdjudicacionPedidoFirmante;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosFirmantes odaAdjudicacionesPedidosFirmantes= new daAdjudicacionesPedidosFirmantes();
				IdAdjudicacionPedidoFirmante =  odaAdjudicacionesPedidosFirmantes.actualizarAdjudicacionesPedidosFirmantes(con, obeAdjudicacionesPedidosFirmantes);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedidoFirmante;
			}
	}

	public int eliminarAdjudicacionesPedidosFirmantes(int IdAdjudicacionPedidoFirmante)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosFirmantes odaAdjudicacionesPedidosFirmantes= new daAdjudicacionesPedidosFirmantes();
				IdAdjudicacionPedidoFirmante =  odaAdjudicacionesPedidosFirmantes.eliminarAdjudicacionesPedidosFirmantes(con, IdAdjudicacionPedidoFirmante);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedidoFirmante;
			}
	}

	public beAdjudicacionesPedidosFirmantes traerAdjudicacionesPedidosFirmantes_x_IdAdjudicacionPedidoFirmante (int IdAdjudicacionPedidoFirmante)
	{
		beAdjudicacionesPedidosFirmantes obeAdjudicacionesPedidosFirmantes=new beAdjudicacionesPedidosFirmantes();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosFirmantes odaAdjudicacionesPedidosFirmantes= new daAdjudicacionesPedidosFirmantes();
				 obeAdjudicacionesPedidosFirmantes =  odaAdjudicacionesPedidosFirmantes.traerAdjudicacionesPedidosFirmantes_x_IdAdjudicacionPedidoFirmante(con, IdAdjudicacionPedidoFirmante);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesPedidosFirmantes;
			}
	}

	public List<beAdjudicacionesPedidosFirmantes> listarTodos_AdjudicacionesPedidosFirmantes()
	 {
		List<beAdjudicacionesPedidosFirmantes> lbeAdjudicacionesPedidosFirmantes =new List<beAdjudicacionesPedidosFirmantes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosFirmantes odaAdjudicacionesPedidosFirmantes= new daAdjudicacionesPedidosFirmantes();
				 lbeAdjudicacionesPedidosFirmantes =  odaAdjudicacionesPedidosFirmantes.listarTodos_AdjudicacionesPedidosFirmantes(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidosFirmantes;
		}
	}
	public List<beAdjudicacionesPedidosFirmantes> listarTodos_AdjudicacionesPedidosFirmantes_GetAll()
	 {
		List<beAdjudicacionesPedidosFirmantes> lbeAdjudicacionesPedidosFirmantes =new List<beAdjudicacionesPedidosFirmantes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosFirmantes odaAdjudicacionesPedidosFirmantes= new daAdjudicacionesPedidosFirmantes();
				 lbeAdjudicacionesPedidosFirmantes =  odaAdjudicacionesPedidosFirmantes.listar_AdjudicacionesPedidosFirmantes_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidosFirmantes;
		}
	}
}
}

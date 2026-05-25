using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesPedidosDetalles:brConexion
		 {
	public int guardarAdjudicacionesPedidosDetalles(beAdjudicacionesPedidosDetalles obeAdjudicacionesPedidosDetalles)
	{
		int IdAdjudicacionPedidoDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesPedidosDetalles odaAdjudicacionesPedidosDetalles= new daAdjudicacionesPedidosDetalles();
			IdAdjudicacionPedidoDetalle =  odaAdjudicacionesPedidosDetalles.guardarAdjudicacionesPedidosDetalles(con, obeAdjudicacionesPedidosDetalles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedidoDetalle;
			}
	}

	public int actualizarAdjudicacionesPedidosDetalles(beAdjudicacionesPedidosDetalles obeAdjudicacionesPedidosDetalles)
	{
		int IdAdjudicacionPedidoDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosDetalles odaAdjudicacionesPedidosDetalles= new daAdjudicacionesPedidosDetalles();
				IdAdjudicacionPedidoDetalle =  odaAdjudicacionesPedidosDetalles.actualizarAdjudicacionesPedidosDetalles(con, obeAdjudicacionesPedidosDetalles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedidoDetalle;
			}
	}

	public int eliminarAdjudicacionesPedidosDetalles(int IdAdjudicacionPedidoDetalle)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosDetalles odaAdjudicacionesPedidosDetalles= new daAdjudicacionesPedidosDetalles();
				IdAdjudicacionPedidoDetalle =  odaAdjudicacionesPedidosDetalles.eliminarAdjudicacionesPedidosDetalles(con, IdAdjudicacionPedidoDetalle);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedidoDetalle;
			}
	}

	public beAdjudicacionesPedidosDetalles traerAdjudicacionesPedidosDetalles_x_IdAdjudicacionPedidoDetalle (int IdAdjudicacionPedidoDetalle)
	{
		beAdjudicacionesPedidosDetalles obeAdjudicacionesPedidosDetalles=new beAdjudicacionesPedidosDetalles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosDetalles odaAdjudicacionesPedidosDetalles= new daAdjudicacionesPedidosDetalles();
				 obeAdjudicacionesPedidosDetalles =  odaAdjudicacionesPedidosDetalles.traerAdjudicacionesPedidosDetalles_x_IdAdjudicacionPedidoDetalle(con, IdAdjudicacionPedidoDetalle);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesPedidosDetalles;
			}
	}

	public List<beAdjudicacionesPedidosDetalles> listarTodos_AdjudicacionesPedidosDetalles()
	 {
		List<beAdjudicacionesPedidosDetalles> lbeAdjudicacionesPedidosDetalles =new List<beAdjudicacionesPedidosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosDetalles odaAdjudicacionesPedidosDetalles= new daAdjudicacionesPedidosDetalles();
				 lbeAdjudicacionesPedidosDetalles =  odaAdjudicacionesPedidosDetalles.listarTodos_AdjudicacionesPedidosDetalles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidosDetalles;
		}
	}
	public List<beAdjudicacionesPedidosDetalles> listarTodos_AdjudicacionesPedidosDetalles_GetAll()
	 {
		List<beAdjudicacionesPedidosDetalles> lbeAdjudicacionesPedidosDetalles =new List<beAdjudicacionesPedidosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidosDetalles odaAdjudicacionesPedidosDetalles= new daAdjudicacionesPedidosDetalles();
				 lbeAdjudicacionesPedidosDetalles =  odaAdjudicacionesPedidosDetalles.listar_AdjudicacionesPedidosDetalles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidosDetalles;
		}
	}
}
}

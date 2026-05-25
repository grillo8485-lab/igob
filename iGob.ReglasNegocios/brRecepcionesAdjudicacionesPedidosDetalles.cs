using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRecepcionesAdjudicacionesPedidosDetalles:brConexion
		 {
	public int guardarRecepcionesAdjudicacionesPedidosDetalles(beRecepcionesAdjudicacionesPedidosDetalles obeRecepcionesAdjudicacionesPedidosDetalles)
	{
		int IdRecepcionAdjudicacionDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRecepcionesAdjudicacionesPedidosDetalles odaRecepcionesAdjudicacionesPedidosDetalles= new daRecepcionesAdjudicacionesPedidosDetalles();
			IdRecepcionAdjudicacionDetalle =  odaRecepcionesAdjudicacionesPedidosDetalles.guardarRecepcionesAdjudicacionesPedidosDetalles(con, obeRecepcionesAdjudicacionesPedidosDetalles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRecepcionAdjudicacionDetalle;
			}
	}

	public int actualizarRecepcionesAdjudicacionesPedidosDetalles(beRecepcionesAdjudicacionesPedidosDetalles obeRecepcionesAdjudicacionesPedidosDetalles)
	{
		int IdRecepcionAdjudicacionDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesAdjudicacionesPedidosDetalles odaRecepcionesAdjudicacionesPedidosDetalles= new daRecepcionesAdjudicacionesPedidosDetalles();
				IdRecepcionAdjudicacionDetalle =  odaRecepcionesAdjudicacionesPedidosDetalles.actualizarRecepcionesAdjudicacionesPedidosDetalles(con, obeRecepcionesAdjudicacionesPedidosDetalles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRecepcionAdjudicacionDetalle;
			}
	}

	public int eliminarRecepcionesAdjudicacionesPedidosDetalles(int IdRecepcionAdjudicacionDetalle)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesAdjudicacionesPedidosDetalles odaRecepcionesAdjudicacionesPedidosDetalles= new daRecepcionesAdjudicacionesPedidosDetalles();
				IdRecepcionAdjudicacionDetalle =  odaRecepcionesAdjudicacionesPedidosDetalles.eliminarRecepcionesAdjudicacionesPedidosDetalles(con, IdRecepcionAdjudicacionDetalle);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRecepcionAdjudicacionDetalle;
			}
	}

	public beRecepcionesAdjudicacionesPedidosDetalles traerRecepcionesAdjudicacionesPedidosDetalles_x_IdRecepcionAdjudicacionDetalle (int IdRecepcionAdjudicacionDetalle)
	{
		beRecepcionesAdjudicacionesPedidosDetalles obeRecepcionesAdjudicacionesPedidosDetalles=new beRecepcionesAdjudicacionesPedidosDetalles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesAdjudicacionesPedidosDetalles odaRecepcionesAdjudicacionesPedidosDetalles= new daRecepcionesAdjudicacionesPedidosDetalles();
				 obeRecepcionesAdjudicacionesPedidosDetalles =  odaRecepcionesAdjudicacionesPedidosDetalles.traerRecepcionesAdjudicacionesPedidosDetalles_x_IdRecepcionAdjudicacionDetalle(con, IdRecepcionAdjudicacionDetalle);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRecepcionesAdjudicacionesPedidosDetalles;
			}
	}

	public List<beRecepcionesAdjudicacionesPedidosDetalles> listarTodos_RecepcionesAdjudicacionesPedidosDetalles()
	 {
		List<beRecepcionesAdjudicacionesPedidosDetalles> lbeRecepcionesAdjudicacionesPedidosDetalles =new List<beRecepcionesAdjudicacionesPedidosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesAdjudicacionesPedidosDetalles odaRecepcionesAdjudicacionesPedidosDetalles= new daRecepcionesAdjudicacionesPedidosDetalles();
				 lbeRecepcionesAdjudicacionesPedidosDetalles =  odaRecepcionesAdjudicacionesPedidosDetalles.listarTodos_RecepcionesAdjudicacionesPedidosDetalles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRecepcionesAdjudicacionesPedidosDetalles;
		}
	}
	public List<beRecepcionesAdjudicacionesPedidosDetalles> listarTodos_RecepcionesAdjudicacionesPedidosDetalles_GetAll()
	 {
		List<beRecepcionesAdjudicacionesPedidosDetalles> lbeRecepcionesAdjudicacionesPedidosDetalles =new List<beRecepcionesAdjudicacionesPedidosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRecepcionesAdjudicacionesPedidosDetalles odaRecepcionesAdjudicacionesPedidosDetalles= new daRecepcionesAdjudicacionesPedidosDetalles();
				 lbeRecepcionesAdjudicacionesPedidosDetalles =  odaRecepcionesAdjudicacionesPedidosDetalles.listar_RecepcionesAdjudicacionesPedidosDetalles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRecepcionesAdjudicacionesPedidosDetalles;
		}
	}
}
}

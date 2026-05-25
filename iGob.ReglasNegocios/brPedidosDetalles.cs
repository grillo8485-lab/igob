using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPedidosDetalles:brConexion
		 {
	public int guardarPedidosDetalles(bePedidosDetalles obePedidosDetalles)
	{
		int IdPedidoDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPedidosDetalles odaPedidosDetalles= new daPedidosDetalles();
			IdPedidoDetalle =  odaPedidosDetalles.guardarPedidosDetalles(con, obePedidosDetalles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedidoDetalle;
			}
	}

	public int actualizarPedidosDetalles(bePedidosDetalles obePedidosDetalles)
	{
		int IdPedidoDetalle;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosDetalles odaPedidosDetalles= new daPedidosDetalles();
				IdPedidoDetalle =  odaPedidosDetalles.actualizarPedidosDetalles(con, obePedidosDetalles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedidoDetalle;
			}
	}

	public int eliminarPedidosDetalles(int IdPedidoDetalle)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosDetalles odaPedidosDetalles= new daPedidosDetalles();
				IdPedidoDetalle =  odaPedidosDetalles.eliminarPedidosDetalles(con, IdPedidoDetalle);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedidoDetalle;
			}
	}

	public bePedidosDetalles traerPedidosDetalles_x_IdPedidoDetalle (int IdPedidoDetalle)
	{
		bePedidosDetalles obePedidosDetalles=new bePedidosDetalles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosDetalles odaPedidosDetalles= new daPedidosDetalles();
				 obePedidosDetalles =  odaPedidosDetalles.traerPedidosDetalles_x_IdPedidoDetalle(con, IdPedidoDetalle);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePedidosDetalles;
			}
	}

	public List<bePedidosDetalles> listarTodos_PedidosDetalles()
	 {
		List<bePedidosDetalles> lbePedidosDetalles =new List<bePedidosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosDetalles odaPedidosDetalles= new daPedidosDetalles();
				 lbePedidosDetalles =  odaPedidosDetalles.listarTodos_PedidosDetalles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidosDetalles;
		}
	}
	public List<bePedidosDetalles> listarTodos_PedidosDetalles_GetAll()
	 {
		List<bePedidosDetalles> lbePedidosDetalles =new List<bePedidosDetalles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosDetalles odaPedidosDetalles= new daPedidosDetalles();
				 lbePedidosDetalles =  odaPedidosDetalles.listar_PedidosDetalles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidosDetalles;
		}
	}
}
}

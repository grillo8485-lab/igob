using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPedidos:brConexion
		 {
	public int guardarPedidos(bePedidos obePedidos)
	{
		int IdPedido;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPedidos odaPedidos= new daPedidos();
			IdPedido =  odaPedidos.guardarPedidos(con, obePedidos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedido;
			}
	}

	public int actualizarPedidos(bePedidos obePedidos)
	{
		int IdPedido;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidos odaPedidos= new daPedidos();
				IdPedido =  odaPedidos.actualizarPedidos(con, obePedidos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedido;
			}
	}

	public int eliminarPedidos(int IdPedido)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidos odaPedidos= new daPedidos();
				IdPedido =  odaPedidos.eliminarPedidos(con, IdPedido);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedido;
			}
	}

	public bePedidos traerPedidos_x_IdPedido (int IdPedido)
	{
		bePedidos obePedidos=new bePedidos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidos odaPedidos= new daPedidos();
				 obePedidos =  odaPedidos.traerPedidos_x_IdPedido(con, IdPedido);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePedidos;
			}
	}

	public List<bePedidos> listarTodos_Pedidos()
	 {
		List<bePedidos> lbePedidos =new List<bePedidos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidos odaPedidos= new daPedidos();
				 lbePedidos =  odaPedidos.listarTodos_Pedidos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidos;
		}
	}
	public List<bePedidos> listarTodos_Pedidos_GetAll()
	 {
		List<bePedidos> lbePedidos =new List<bePedidos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidos odaPedidos= new daPedidos();
				 lbePedidos =  odaPedidos.listar_Pedidos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidos;
		}
	}
}
}

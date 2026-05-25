using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesPedidos:brConexion
		 {
	public int guardarAdjudicacionesPedidos(beAdjudicacionesPedidos obeAdjudicacionesPedidos)
	{
		int IdAdjudicacionPedido;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesPedidos odaAdjudicacionesPedidos= new daAdjudicacionesPedidos();
			IdAdjudicacionPedido =  odaAdjudicacionesPedidos.guardarAdjudicacionesPedidos(con, obeAdjudicacionesPedidos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedido;
			}
	}

	public int actualizarAdjudicacionesPedidos(beAdjudicacionesPedidos obeAdjudicacionesPedidos)
	{
		int IdAdjudicacionPedido;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidos odaAdjudicacionesPedidos= new daAdjudicacionesPedidos();
				IdAdjudicacionPedido =  odaAdjudicacionesPedidos.actualizarAdjudicacionesPedidos(con, obeAdjudicacionesPedidos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedido;
			}
	}

	public int eliminarAdjudicacionesPedidos(int IdAdjudicacionPedido)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidos odaAdjudicacionesPedidos= new daAdjudicacionesPedidos();
				IdAdjudicacionPedido =  odaAdjudicacionesPedidos.eliminarAdjudicacionesPedidos(con, IdAdjudicacionPedido);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicacionPedido;
			}
	}

	public beAdjudicacionesPedidos traerAdjudicacionesPedidos_x_IdAdjudicacionPedido (int IdAdjudicacionPedido)
	{
		beAdjudicacionesPedidos obeAdjudicacionesPedidos=new beAdjudicacionesPedidos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidos odaAdjudicacionesPedidos= new daAdjudicacionesPedidos();
				 obeAdjudicacionesPedidos =  odaAdjudicacionesPedidos.traerAdjudicacionesPedidos_x_IdAdjudicacionPedido(con, IdAdjudicacionPedido);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesPedidos;
			}
	}

	public List<beAdjudicacionesPedidos> listarTodos_AdjudicacionesPedidos()
	 {
		List<beAdjudicacionesPedidos> lbeAdjudicacionesPedidos =new List<beAdjudicacionesPedidos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidos odaAdjudicacionesPedidos= new daAdjudicacionesPedidos();
				 lbeAdjudicacionesPedidos =  odaAdjudicacionesPedidos.listarTodos_AdjudicacionesPedidos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidos;
		}
	}
	public List<beAdjudicacionesPedidos> listarTodos_AdjudicacionesPedidos_GetAll()
	 {
		List<beAdjudicacionesPedidos> lbeAdjudicacionesPedidos =new List<beAdjudicacionesPedidos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPedidos odaAdjudicacionesPedidos= new daAdjudicacionesPedidos();
				 lbeAdjudicacionesPedidos =  odaAdjudicacionesPedidos.listar_AdjudicacionesPedidos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidos;
		}
	}
}
}

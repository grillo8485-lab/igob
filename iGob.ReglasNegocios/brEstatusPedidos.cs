using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brEstatusPedidos:brConexion
		 {
	public int guardarEstatusPedidos(beEstatusPedidos obeEstatusPedidos)
	{
		int IdEstatusPedido;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daEstatusPedidos odaEstatusPedidos= new daEstatusPedidos();
			IdEstatusPedido =  odaEstatusPedidos.guardarEstatusPedidos(con, obeEstatusPedidos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPedido;
			}
	}

	public int actualizarEstatusPedidos(beEstatusPedidos obeEstatusPedidos)
	{
		int IdEstatusPedido;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPedidos odaEstatusPedidos= new daEstatusPedidos();
				IdEstatusPedido =  odaEstatusPedidos.actualizarEstatusPedidos(con, obeEstatusPedidos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPedido;
			}
	}

	public int eliminarEstatusPedidos(int IdEstatusPedido)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPedidos odaEstatusPedidos= new daEstatusPedidos();
				IdEstatusPedido =  odaEstatusPedidos.eliminarEstatusPedidos(con, IdEstatusPedido);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPedido;
			}
	}

	public beEstatusPedidos traerEstatusPedidos_x_IdEstatusPedido (int IdEstatusPedido)
	{
		beEstatusPedidos obeEstatusPedidos=new beEstatusPedidos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPedidos odaEstatusPedidos= new daEstatusPedidos();
				 obeEstatusPedidos =  odaEstatusPedidos.traerEstatusPedidos_x_IdEstatusPedido(con, IdEstatusPedido);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusPedidos;
			}
	}

	public List<beEstatusPedidos> listarTodos_EstatusPedidos()
	 {
		List<beEstatusPedidos> lbeEstatusPedidos =new List<beEstatusPedidos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPedidos odaEstatusPedidos= new daEstatusPedidos();
				 lbeEstatusPedidos =  odaEstatusPedidos.listarTodos_EstatusPedidos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPedidos;
		}
	}
	public List<beEstatusPedidos> listarTodos_EstatusPedidos_GetAll()
	 {
		List<beEstatusPedidos> lbeEstatusPedidos =new List<beEstatusPedidos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPedidos odaEstatusPedidos= new daEstatusPedidos();
				 lbeEstatusPedidos =  odaEstatusPedidos.listar_EstatusPedidos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPedidos;
		}
	}
}
}

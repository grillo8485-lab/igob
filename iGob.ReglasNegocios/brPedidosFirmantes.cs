using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPedidosFirmantes:brConexion
		 {
	public int guardarPedidosFirmantes(bePedidosFirmantes obePedidosFirmantes)
	{
		int IdPedidoFirmante;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPedidosFirmantes odaPedidosFirmantes= new daPedidosFirmantes();
			IdPedidoFirmante =  odaPedidosFirmantes.guardarPedidosFirmantes(con, obePedidosFirmantes);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedidoFirmante;
			}
	}

	public int actualizarPedidosFirmantes(bePedidosFirmantes obePedidosFirmantes)
	{
		int IdPedidoFirmante;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosFirmantes odaPedidosFirmantes= new daPedidosFirmantes();
				IdPedidoFirmante =  odaPedidosFirmantes.actualizarPedidosFirmantes(con, obePedidosFirmantes);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedidoFirmante;
			}
	}

	public int eliminarPedidosFirmantes(int IdPedidoFirmante)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosFirmantes odaPedidosFirmantes= new daPedidosFirmantes();
				IdPedidoFirmante =  odaPedidosFirmantes.eliminarPedidosFirmantes(con, IdPedidoFirmante);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPedidoFirmante;
			}
	}

	public bePedidosFirmantes traerPedidosFirmantes_x_IdPedidoFirmante (int IdPedidoFirmante)
	{
		bePedidosFirmantes obePedidosFirmantes=new bePedidosFirmantes();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosFirmantes odaPedidosFirmantes= new daPedidosFirmantes();
				 obePedidosFirmantes =  odaPedidosFirmantes.traerPedidosFirmantes_x_IdPedidoFirmante(con, IdPedidoFirmante);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePedidosFirmantes;
			}
	}

	public List<bePedidosFirmantes> listarTodos_PedidosFirmantes()
	 {
		List<bePedidosFirmantes> lbePedidosFirmantes =new List<bePedidosFirmantes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosFirmantes odaPedidosFirmantes= new daPedidosFirmantes();
				 lbePedidosFirmantes =  odaPedidosFirmantes.listarTodos_PedidosFirmantes(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidosFirmantes;
		}
	}
	public List<bePedidosFirmantes> listarTodos_PedidosFirmantes_GetAll()
	 {
		List<bePedidosFirmantes> lbePedidosFirmantes =new List<bePedidosFirmantes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPedidosFirmantes odaPedidosFirmantes= new daPedidosFirmantes();
				 lbePedidosFirmantes =  odaPedidosFirmantes.listar_PedidosFirmantes_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidosFirmantes;
		}
	}
}
}

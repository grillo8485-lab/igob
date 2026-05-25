using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposProductos:brConexion
		 {
	public int guardarTiposProductos(beTiposProductos obeTiposProductos)
	{
		int IdTipoProducto;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposProductos odaTiposProductos= new daTiposProductos();
			IdTipoProducto =  odaTiposProductos.guardarTiposProductos(con, obeTiposProductos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoProducto;
			}
	}

	public int actualizarTiposProductos(beTiposProductos obeTiposProductos)
	{
		int IdTipoProducto;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProductos odaTiposProductos= new daTiposProductos();
				IdTipoProducto =  odaTiposProductos.actualizarTiposProductos(con, obeTiposProductos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoProducto;
			}
	}

	public int eliminarTiposProductos(int IdTipoProducto)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProductos odaTiposProductos= new daTiposProductos();
				IdTipoProducto =  odaTiposProductos.eliminarTiposProductos(con, IdTipoProducto);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoProducto;
			}
	}

	public beTiposProductos traerTiposProductos_x_IdTipoProducto (int IdTipoProducto)
	{
		beTiposProductos obeTiposProductos=new beTiposProductos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProductos odaTiposProductos= new daTiposProductos();
				 obeTiposProductos =  odaTiposProductos.traerTiposProductos_x_IdTipoProducto(con, IdTipoProducto);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposProductos;
			}
	}

	public List<beTiposProductos> listarTodos_TiposProductos()
	 {
		List<beTiposProductos> lbeTiposProductos =new List<beTiposProductos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProductos odaTiposProductos= new daTiposProductos();
				 lbeTiposProductos =  odaTiposProductos.listarTodos_TiposProductos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposProductos;
		}
	}
}
}

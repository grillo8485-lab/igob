using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brProductosScian:brConexion
		 {
	public int guardarProductosScian(beProductosScian obeProductosScian)
	{
		int IdCodigoScian;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daProductosScian odaProductosScian= new daProductosScian();
			IdCodigoScian =  odaProductosScian.guardarProductosScian(con, obeProductosScian);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdCodigoScian;
			}
	}

	public int actualizarProductosScian(beProductosScian obeProductosScian)
	{
		int IdCodigoScian;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProductosScian odaProductosScian= new daProductosScian();
				IdCodigoScian =  odaProductosScian.actualizarProductosScian(con, obeProductosScian);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCodigoScian;
			}
	}

	public int eliminarProductosScian(int IdCodigoScian)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProductosScian odaProductosScian= new daProductosScian();
				IdCodigoScian =  odaProductosScian.eliminarProductosScian(con, IdCodigoScian);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCodigoScian;
			}
	}

	public beProductosScian traerProductosScian_x_IdCodigoScian (int IdCodigoScian)
	{
		beProductosScian obeProductosScian=new beProductosScian();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProductosScian odaProductosScian= new daProductosScian();
				 obeProductosScian =  odaProductosScian.traerProductosScian_x_IdCodigoScian(con, IdCodigoScian);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProductosScian;
			}
	}

	public List<beProductosScian> listarTodos_ProductosScian()
	 {
		List<beProductosScian> lbeProductosScian =new List<beProductosScian>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProductosScian odaProductosScian= new daProductosScian();
				 lbeProductosScian =  odaProductosScian.listarTodos_ProductosScian(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProductosScian;
		}
	}
	public List<beProductosScian> listarTodos_ProductosScian_GetAll()
	 {
		List<beProductosScian> lbeProductosScian =new List<beProductosScian>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProductosScian odaProductosScian= new daProductosScian();
				 lbeProductosScian =  odaProductosScian.listar_ProductosScian_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProductosScian;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposCondiciones:brConexion
		 {
	public int guardarTiposCondiciones(beTiposCondiciones obeTiposCondiciones)
	{
		int IdTipoCondicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposCondiciones odaTiposCondiciones= new daTiposCondiciones();
			IdTipoCondicion =  odaTiposCondiciones.guardarTiposCondiciones(con, obeTiposCondiciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCondicion;
			}
	}

	public int actualizarTiposCondiciones(beTiposCondiciones obeTiposCondiciones)
	{
		int IdTipoCondicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCondiciones odaTiposCondiciones= new daTiposCondiciones();
				IdTipoCondicion =  odaTiposCondiciones.actualizarTiposCondiciones(con, obeTiposCondiciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCondicion;
			}
	}

	public int eliminarTiposCondiciones(int IdTipoCondicion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCondiciones odaTiposCondiciones= new daTiposCondiciones();
				IdTipoCondicion =  odaTiposCondiciones.eliminarTiposCondiciones(con, IdTipoCondicion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCondicion;
			}
	}

	public beTiposCondiciones traerTiposCondiciones_x_IdTipoCondicion (int IdTipoCondicion)
	{
		beTiposCondiciones obeTiposCondiciones=new beTiposCondiciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCondiciones odaTiposCondiciones= new daTiposCondiciones();
				 obeTiposCondiciones =  odaTiposCondiciones.traerTiposCondiciones_x_IdTipoCondicion(con, IdTipoCondicion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposCondiciones;
			}
	}

	public List<beTiposCondiciones> listarTodos_TiposCondiciones()
	 {
		List<beTiposCondiciones> lbeTiposCondiciones =new List<beTiposCondiciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCondiciones odaTiposCondiciones= new daTiposCondiciones();
				 lbeTiposCondiciones =  odaTiposCondiciones.listarTodos_TiposCondiciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposCondiciones;
		}
	}
}
}

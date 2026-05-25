using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposLicitaciones:brConexion
		 {
	public int guardarTiposLicitaciones(beTiposLicitaciones obeTiposLicitaciones)
	{
		int IdTipoLicitacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposLicitaciones odaTiposLicitaciones= new daTiposLicitaciones();
			IdTipoLicitacion =  odaTiposLicitaciones.guardarTiposLicitaciones(con, obeTiposLicitaciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLicitacion;
			}
	}

	public int actualizarTiposLicitaciones(beTiposLicitaciones obeTiposLicitaciones)
	{
		int IdTipoLicitacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLicitaciones odaTiposLicitaciones= new daTiposLicitaciones();
				IdTipoLicitacion =  odaTiposLicitaciones.actualizarTiposLicitaciones(con, obeTiposLicitaciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLicitacion;
			}
	}

	public int eliminarTiposLicitaciones(int IdTipoLicitacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLicitaciones odaTiposLicitaciones= new daTiposLicitaciones();
				IdTipoLicitacion =  odaTiposLicitaciones.eliminarTiposLicitaciones(con, IdTipoLicitacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLicitacion;
			}
	}

	public beTiposLicitaciones traerTiposLicitaciones_x_IdTipoLicitacion (int IdTipoLicitacion)
	{
		beTiposLicitaciones obeTiposLicitaciones=new beTiposLicitaciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLicitaciones odaTiposLicitaciones= new daTiposLicitaciones();
				 obeTiposLicitaciones =  odaTiposLicitaciones.traerTiposLicitaciones_x_IdTipoLicitacion(con, IdTipoLicitacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposLicitaciones;
			}
	}

	public List<beTiposLicitaciones> listarTodos_TiposLicitaciones()
	 {
		List<beTiposLicitaciones> lbeTiposLicitaciones =new List<beTiposLicitaciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLicitaciones odaTiposLicitaciones= new daTiposLicitaciones();
				 lbeTiposLicitaciones =  odaTiposLicitaciones.listarTodos_TiposLicitaciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLicitaciones;
		}
	}
	public List<beTiposLicitaciones> listarTodos_TiposLicitaciones_GetAll()
	 {
		List<beTiposLicitaciones> lbeTiposLicitaciones =new List<beTiposLicitaciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLicitaciones odaTiposLicitaciones= new daTiposLicitaciones();
				 lbeTiposLicitaciones =  odaTiposLicitaciones.listar_TiposLicitaciones_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLicitaciones;
		}
	}
}
}

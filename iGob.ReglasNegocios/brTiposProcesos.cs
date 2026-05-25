using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposProcesos:brConexion
		 {
	public int guardarTiposProcesos(beTiposProcesos obeTiposProcesos)
	{
		int IdTipoProceso;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposProcesos odaTiposProcesos= new daTiposProcesos();
			IdTipoProceso =  odaTiposProcesos.guardarTiposProcesos(con, obeTiposProcesos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoProceso;
			}
	}

	public int actualizarTiposProcesos(beTiposProcesos obeTiposProcesos)
	{
		int IdTipoProceso;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProcesos odaTiposProcesos= new daTiposProcesos();
				IdTipoProceso =  odaTiposProcesos.actualizarTiposProcesos(con, obeTiposProcesos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoProceso;
			}
	}

	public int eliminarTiposProcesos(int IdTipoProceso)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProcesos odaTiposProcesos= new daTiposProcesos();
				IdTipoProceso =  odaTiposProcesos.eliminarTiposProcesos(con, IdTipoProceso);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoProceso;
			}
	}

	public beTiposProcesos traerTiposProcesos_x_IdTipoProceso (int IdTipoProceso)
	{
		beTiposProcesos obeTiposProcesos=new beTiposProcesos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProcesos odaTiposProcesos= new daTiposProcesos();
				 obeTiposProcesos =  odaTiposProcesos.traerTiposProcesos_x_IdTipoProceso(con, IdTipoProceso);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposProcesos;
			}
	}

	public List<beTiposProcesos> listarTodos_TiposProcesos()
	 {
		List<beTiposProcesos> lbeTiposProcesos =new List<beTiposProcesos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProcesos odaTiposProcesos= new daTiposProcesos();
				 lbeTiposProcesos =  odaTiposProcesos.listarTodos_TiposProcesos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposProcesos;
		}
	}
	public List<beTiposProcesos> listarTodos_TiposProcesos_GetAll()
	 {
		List<beTiposProcesos> lbeTiposProcesos =new List<beTiposProcesos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposProcesos odaTiposProcesos= new daTiposProcesos();
				 lbeTiposProcesos =  odaTiposProcesos.listar_TiposProcesos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposProcesos;
		}
	}
}
}

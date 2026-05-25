using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposAdjudicacion:brConexion
		 {
	public int guardarTiposAdjudicacion(beTiposAdjudicacion obeTiposAdjudicacion)
	{
		int IdTipoAdjudicacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposAdjudicacion odaTiposAdjudicacion= new daTiposAdjudicacion();
			IdTipoAdjudicacion =  odaTiposAdjudicacion.guardarTiposAdjudicacion(con, obeTiposAdjudicacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoAdjudicacion;
			}
	}

	public int actualizarTiposAdjudicacion(beTiposAdjudicacion obeTiposAdjudicacion)
	{
		int IdTipoAdjudicacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposAdjudicacion odaTiposAdjudicacion= new daTiposAdjudicacion();
				IdTipoAdjudicacion =  odaTiposAdjudicacion.actualizarTiposAdjudicacion(con, obeTiposAdjudicacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoAdjudicacion;
			}
	}

	public int eliminarTiposAdjudicacion(int IdTipoAdjudicacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposAdjudicacion odaTiposAdjudicacion= new daTiposAdjudicacion();
				IdTipoAdjudicacion =  odaTiposAdjudicacion.eliminarTiposAdjudicacion(con, IdTipoAdjudicacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoAdjudicacion;
			}
	}

	public beTiposAdjudicacion traerTiposAdjudicacion_x_IdTipoAdjudicacion (int IdTipoAdjudicacion)
	{
		beTiposAdjudicacion obeTiposAdjudicacion=new beTiposAdjudicacion();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposAdjudicacion odaTiposAdjudicacion= new daTiposAdjudicacion();
				 obeTiposAdjudicacion =  odaTiposAdjudicacion.traerTiposAdjudicacion_x_IdTipoAdjudicacion(con, IdTipoAdjudicacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposAdjudicacion;
			}
	}

	public List<beTiposAdjudicacion> listarTodos_TiposAdjudicacion()
	 {
		List<beTiposAdjudicacion> lbeTiposAdjudicacion =new List<beTiposAdjudicacion>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposAdjudicacion odaTiposAdjudicacion= new daTiposAdjudicacion();
				 lbeTiposAdjudicacion =  odaTiposAdjudicacion.listarTodos_TiposAdjudicacion(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposAdjudicacion;
		}
	}
	public List<beTiposAdjudicacion> listarTodos_TiposAdjudicacion_GetAll()
	 {
		List<beTiposAdjudicacion> lbeTiposAdjudicacion =new List<beTiposAdjudicacion>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposAdjudicacion odaTiposAdjudicacion= new daTiposAdjudicacion();
				 lbeTiposAdjudicacion =  odaTiposAdjudicacion.listar_TiposAdjudicacion_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposAdjudicacion;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposSolicitud:brConexion
		 {
	public int guardarTiposSolicitud(beTiposSolicitud obeTiposSolicitud)
	{
		int IdTipoSolicitud;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposSolicitud odaTiposSolicitud= new daTiposSolicitud();
			IdTipoSolicitud =  odaTiposSolicitud.guardarTiposSolicitud(con, obeTiposSolicitud);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoSolicitud;
			}
	}

	public int actualizarTiposSolicitud(beTiposSolicitud obeTiposSolicitud)
	{
		int IdTipoSolicitud;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposSolicitud odaTiposSolicitud= new daTiposSolicitud();
				IdTipoSolicitud =  odaTiposSolicitud.actualizarTiposSolicitud(con, obeTiposSolicitud);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoSolicitud;
			}
	}

	public int eliminarTiposSolicitud(int IdTipoSolicitud)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposSolicitud odaTiposSolicitud= new daTiposSolicitud();
				IdTipoSolicitud =  odaTiposSolicitud.eliminarTiposSolicitud(con, IdTipoSolicitud);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoSolicitud;
			}
	}

	public beTiposSolicitud traerTiposSolicitud_x_IdTipoSolicitud (int IdTipoSolicitud)
	{
		beTiposSolicitud obeTiposSolicitud=new beTiposSolicitud();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposSolicitud odaTiposSolicitud= new daTiposSolicitud();
				 obeTiposSolicitud =  odaTiposSolicitud.traerTiposSolicitud_x_IdTipoSolicitud(con, IdTipoSolicitud);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposSolicitud;
			}
	}

	public List<beTiposSolicitud> listarTodos_TiposSolicitud()
	 {
		List<beTiposSolicitud> lbeTiposSolicitud =new List<beTiposSolicitud>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposSolicitud odaTiposSolicitud= new daTiposSolicitud();
				 lbeTiposSolicitud =  odaTiposSolicitud.listarTodos_TiposSolicitud(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposSolicitud;
		}
	}
	public List<beTiposSolicitud> listarTodos_TiposSolicitud_GetAll()
	 {
		List<beTiposSolicitud> lbeTiposSolicitud =new List<beTiposSolicitud>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposSolicitud odaTiposSolicitud= new daTiposSolicitud();
				 lbeTiposSolicitud =  odaTiposSolicitud.listar_TiposSolicitud_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposSolicitud;
		}
	}
}
}

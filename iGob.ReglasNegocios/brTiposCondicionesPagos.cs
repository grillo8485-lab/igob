using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposCondicionesPagos:brConexion
		 {
	public int guardarTiposCondicionesPagos(beTiposCondicionesPagos obeTiposCondicionesPagos)
	{
		int IdTipoCondicionPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposCondicionesPagos odaTiposCondicionesPagos= new daTiposCondicionesPagos();
			IdTipoCondicionPago =  odaTiposCondicionesPagos.guardarTiposCondicionesPagos(con, obeTiposCondicionesPagos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCondicionPago;
			}
	}

	public int actualizarTiposCondicionesPagos(beTiposCondicionesPagos obeTiposCondicionesPagos)
	{
		int IdTipoCondicionPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCondicionesPagos odaTiposCondicionesPagos= new daTiposCondicionesPagos();
				IdTipoCondicionPago =  odaTiposCondicionesPagos.actualizarTiposCondicionesPagos(con, obeTiposCondicionesPagos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCondicionPago;
			}
	}

	public int eliminarTiposCondicionesPagos(int IdTipoCondicionPago)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCondicionesPagos odaTiposCondicionesPagos= new daTiposCondicionesPagos();
				IdTipoCondicionPago =  odaTiposCondicionesPagos.eliminarTiposCondicionesPagos(con, IdTipoCondicionPago);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoCondicionPago;
			}
	}

	public beTiposCondicionesPagos traerTiposCondicionesPagos_x_IdTipoCondicionPago (int IdTipoCondicionPago)
	{
		beTiposCondicionesPagos obeTiposCondicionesPagos=new beTiposCondicionesPagos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCondicionesPagos odaTiposCondicionesPagos= new daTiposCondicionesPagos();
				 obeTiposCondicionesPagos =  odaTiposCondicionesPagos.traerTiposCondicionesPagos_x_IdTipoCondicionPago(con, IdTipoCondicionPago);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposCondicionesPagos;
			}
	}

	public List<beTiposCondicionesPagos> listarTodos_TiposCondicionesPagos()
	 {
		List<beTiposCondicionesPagos> lbeTiposCondicionesPagos =new List<beTiposCondicionesPagos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposCondicionesPagos odaTiposCondicionesPagos= new daTiposCondicionesPagos();
				 lbeTiposCondicionesPagos =  odaTiposCondicionesPagos.listarTodos_TiposCondicionesPagos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposCondicionesPagos;
		}
	}
}
}

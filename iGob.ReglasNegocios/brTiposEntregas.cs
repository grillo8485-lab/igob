using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposEntregas:brConexion
		 {
	public int guardarTiposEntregas(beTiposEntregas obeTiposEntregas)
	{
		int IdTipoEntrega;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposEntregas odaTiposEntregas= new daTiposEntregas();
			IdTipoEntrega =  odaTiposEntregas.guardarTiposEntregas(con, obeTiposEntregas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoEntrega;
			}
	}

	public int actualizarTiposEntregas(beTiposEntregas obeTiposEntregas)
	{
		int IdTipoEntrega;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposEntregas odaTiposEntregas= new daTiposEntregas();
				IdTipoEntrega =  odaTiposEntregas.actualizarTiposEntregas(con, obeTiposEntregas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoEntrega;
			}
	}

	public int eliminarTiposEntregas(int IdTipoEntrega)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposEntregas odaTiposEntregas= new daTiposEntregas();
				IdTipoEntrega =  odaTiposEntregas.eliminarTiposEntregas(con, IdTipoEntrega);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoEntrega;
			}
	}

	public beTiposEntregas traerTiposEntregas_x_IdTipoEntrega (int IdTipoEntrega)
	{
		beTiposEntregas obeTiposEntregas=new beTiposEntregas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposEntregas odaTiposEntregas= new daTiposEntregas();
				 obeTiposEntregas =  odaTiposEntregas.traerTiposEntregas_x_IdTipoEntrega(con, IdTipoEntrega);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposEntregas;
			}
	}

	public List<beTiposEntregas> listarTodos_TiposEntregas()
	 {
		List<beTiposEntregas> lbeTiposEntregas =new List<beTiposEntregas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposEntregas odaTiposEntregas= new daTiposEntregas();
				 lbeTiposEntregas =  odaTiposEntregas.listarTodos_TiposEntregas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposEntregas;
		}
	}
	public List<beTiposEntregas> listarTodos_TiposEntregas_GetAll()
	 {
		List<beTiposEntregas> lbeTiposEntregas =new List<beTiposEntregas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposEntregas odaTiposEntregas= new daTiposEntregas();
				 lbeTiposEntregas =  odaTiposEntregas.listar_TiposEntregas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposEntregas;
		}
	}
}
}

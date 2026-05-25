using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposPersonas:brConexion
		 {
	public int guardarTiposPersonas(beTiposPersonas obeTiposPersonas)
	{
		int IdTipoPersona;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposPersonas odaTiposPersonas= new daTiposPersonas();
			IdTipoPersona =  odaTiposPersonas.guardarTiposPersonas(con, obeTiposPersonas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoPersona;
			}
	}

	public int actualizarTiposPersonas(beTiposPersonas obeTiposPersonas)
	{
		int IdTipoPersona;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposPersonas odaTiposPersonas= new daTiposPersonas();
				IdTipoPersona =  odaTiposPersonas.actualizarTiposPersonas(con, obeTiposPersonas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoPersona;
			}
	}

	public int eliminarTiposPersonas(int IdTipoPersona)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposPersonas odaTiposPersonas= new daTiposPersonas();
				IdTipoPersona =  odaTiposPersonas.eliminarTiposPersonas(con, IdTipoPersona);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoPersona;
			}
	}

	public beTiposPersonas traerTiposPersonas_x_IdTipoPersona (int IdTipoPersona)
	{
		beTiposPersonas obeTiposPersonas=new beTiposPersonas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposPersonas odaTiposPersonas= new daTiposPersonas();
				 obeTiposPersonas =  odaTiposPersonas.traerTiposPersonas_x_IdTipoPersona(con, IdTipoPersona);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposPersonas;
			}
	}

	public List<beTiposPersonas> listarTodos_TiposPersonas()
	 {
		List<beTiposPersonas> lbeTiposPersonas =new List<beTiposPersonas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposPersonas odaTiposPersonas= new daTiposPersonas();
				 lbeTiposPersonas =  odaTiposPersonas.listarTodos_TiposPersonas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposPersonas;
		}
	}
	public List<beTiposPersonas> listarTodos_TiposPersonas_GetAll()
	 {
		List<beTiposPersonas> lbeTiposPersonas =new List<beTiposPersonas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposPersonas odaTiposPersonas= new daTiposPersonas();
				 lbeTiposPersonas =  odaTiposPersonas.listar_TiposPersonas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposPersonas;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposDias:brConexion
		 {
	public int guardarTiposDias(beTiposDias obeTiposDias)
	{
		int IdTipoDia;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposDias odaTiposDias= new daTiposDias();
			IdTipoDia =  odaTiposDias.guardarTiposDias(con, obeTiposDias);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoDia;
			}
	}

	public int actualizarTiposDias(beTiposDias obeTiposDias)
	{
		int IdTipoDia;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposDias odaTiposDias= new daTiposDias();
				IdTipoDia =  odaTiposDias.actualizarTiposDias(con, obeTiposDias);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoDia;
			}
	}

	public int eliminarTiposDias(int IdTipoDia)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposDias odaTiposDias= new daTiposDias();
				IdTipoDia =  odaTiposDias.eliminarTiposDias(con, IdTipoDia);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoDia;
			}
	}

	public beTiposDias traerTiposDias_x_IdTipoDia (int IdTipoDia)
	{
		beTiposDias obeTiposDias=new beTiposDias();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposDias odaTiposDias= new daTiposDias();
				 obeTiposDias =  odaTiposDias.traerTiposDias_x_IdTipoDia(con, IdTipoDia);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposDias;
			}
	}

	public List<beTiposDias> listarTodos_TiposDias()
	 {
		List<beTiposDias> lbeTiposDias =new List<beTiposDias>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposDias odaTiposDias= new daTiposDias();
				 lbeTiposDias =  odaTiposDias.listarTodos_TiposDias(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposDias;
		}
	}
	public List<beTiposDias> listarTodos_TiposDias_GetAll()
	 {
		List<beTiposDias> lbeTiposDias =new List<beTiposDias>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposDias odaTiposDias= new daTiposDias();
				 lbeTiposDias =  odaTiposDias.listar_TiposDias_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposDias;
		}
	}
}
}

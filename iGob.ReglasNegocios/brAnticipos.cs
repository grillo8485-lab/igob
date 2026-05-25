using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAnticipos:brConexion
		 {
	public int guardarAnticipos(beAnticipos obeAnticipos)
	{
		int IdAnticipo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAnticipos odaAnticipos= new daAnticipos();
			IdAnticipo =  odaAnticipos.guardarAnticipos(con, obeAnticipos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAnticipo;
			}
	}

	public int actualizarAnticipos(beAnticipos obeAnticipos)
	{
		int IdAnticipo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAnticipos odaAnticipos= new daAnticipos();
				IdAnticipo =  odaAnticipos.actualizarAnticipos(con, obeAnticipos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAnticipo;
			}
	}

	public int eliminarAnticipos(int IdAnticipo)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAnticipos odaAnticipos= new daAnticipos();
				IdAnticipo =  odaAnticipos.eliminarAnticipos(con, IdAnticipo);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAnticipo;
			}
	}

	public beAnticipos traerAnticipos_x_IdAnticipo (int IdAnticipo)
	{
		beAnticipos obeAnticipos=new beAnticipos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAnticipos odaAnticipos= new daAnticipos();
				 obeAnticipos =  odaAnticipos.traerAnticipos_x_IdAnticipo(con, IdAnticipo);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAnticipos;
			}
	}

	public List<beAnticipos> listarTodos_Anticipos()
	 {
		List<beAnticipos> lbeAnticipos =new List<beAnticipos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAnticipos odaAnticipos= new daAnticipos();
				 lbeAnticipos =  odaAnticipos.listarTodos_Anticipos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAnticipos;
		}
	}
	public List<beAnticipos> listarTodos_Anticipos_GetAll()
	 {
		List<beAnticipos> lbeAnticipos =new List<beAnticipos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAnticipos odaAnticipos= new daAnticipos();
				 lbeAnticipos =  odaAnticipos.listar_Anticipos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAnticipos;
		}
	}
}
}
